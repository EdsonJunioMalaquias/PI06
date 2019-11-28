<template>
  <div class="content">
    <div class="md-layout">
      <div class="md-layout-item md-small-size-100 md-size-75">
        <md-card>
          <md-card-header data-background-color="green">
            <h4 class="title">Lista de Espera de Pacientes</h4>
            <md-switch class="switch" v-model="filterValue">Filtrar Pacientes Atendidos</md-switch>
          </md-card-header>
          <md-card-content>
            <div>
              <div>
                <md-table v-model="filteredList" :table-header-color="tableHeaderColor">
                  <md-table-row slot="md-table-row" slot-scope="{ item }">
                    <md-table-cell md-label="ID">{{ item.id }}</md-table-cell>
                    <md-table-cell md-label="Nome">{{ item.paciente.pessoa.nome }}</md-table-cell>
                    <md-table-cell md-label="Medico">{{ item.medico.pessoa.nome }}</md-table-cell>
                    <md-table-cell
                      md-label="Data de Chegada"
                    >{{ recebeDateTimeERetornaSomenteODate(item.dataChegada) }}</md-table-cell>
                    <md-table-cell
                      md-label="Hora de Chegada"
                    >{{ recebeDateTimeERetornaSomenteOTime(item.dataChegada) }}</md-table-cell>
                    <md-table-cell md-label="Grau de Emergencia">{{ item.grauDeEmergencia }}</md-table-cell>
                    <md-button
                      @click.prevent="mudarStatusAtendimento(item)"
                      class="md-raised md-success"
                    >Mudar</md-button>
                  </md-table-row>
                </md-table>
              </div>
            </div>
          </md-card-content>
        </md-card>
      </div>
      <div class="md-layout-item md-small-size-100 md-size-25">
        <md-card>
          <md-card-header data-background-color="green">
            <h4 class="title">Adicionar Pacientes</h4>
            <p class="category">Adicionar Pacientes Manualmente</p>
          </md-card-header>

          <md-card-content>
            <div class="md-layout">
              <div class="md-layout-item">
                <md-field>
                  <label for="CPF">CPF</label>
                  <md-input type="text" v-model="cpf" id="CPF" v-mask="'###.###.###-##'"></md-input>
                </md-field>
              </div>
              <div class="md-layout-item">
                <md-field>
                  <label>Medico</label>
                  <md-select v-model="idSelectedMedico" name="medico" id="medico">
                    <md-option
                      v-for="item in this.medicos"
                      :key="item.id"
                      :value="item.id"
                    >{{ item.pessoa.nome }}</md-option>
                  </md-select>
                </md-field>
              </div>

              <div class="md-layout-item">
                <md-field>
                  <label>Grau de Emergência</label>
                  <md-select name="GrauEmergencia" v-model="grauEmergencia" id="GrauEmergencia">
                    <md-option value="1">Emergência</md-option>
                    <md-option value="2">Muito Urgente</md-option>
                    <md-option value="3">Urgente</md-option>
                    <md-option value="4">Pouco Urgente</md-option>
                    <md-option value="5">Não Urgente</md-option>
                  </md-select>
                </md-field>
              </div>
            </div>
            <div class="md-layout">
              <div class="md-layout-item md-small-size-100 md-size-100">
                <md-button
                  @click.prevent="cadastrarAtendimento()"
                  class="md-raised md-success buton"
                >Adicionar na Fila</md-button>
              </div>
              <div class="md-layout-item md-small-size-100 md-size-100">
                <md-button to="/cadastroPessoa" class="md-raised md-success buton">Novo Paciente</md-button>
              </div>
            </div>
          </md-card-content>
        </md-card>
      </div>
    </div>
  </div>
</template>

<script>
import fila from "../../services/fila.js";
import paciente from "../../services/paciente.js";
import funcionario from "../../services/funcionario.js";
import moment from "moment";
import _ from "lodash";

export default {
  name: "ordered-table",
  props: {
    tableHeaderColor: {
      type: String,
      default: ""
    }
  },
  computed: {
    filteredList() {
      let result = this.users;

      const filter = atendimento =>
        atendimento.statusDeAtendimento
          .toString()
          .toLowerCase()
          .includes(this.filterValue.toString().toLowerCase());
      return _.orderBy(result.filter(filter), "grauDeEmergencia");
    }
  },
  data() {
    return {
      users: [],
      filterValue: "false",
      dateTime: "",
      cpf: "",
      grauEmergencia: "",
      medicos: [],
      idSelectedMedico: "",
      pacienteId: ""
    };
  },
  mounted() {
    this.buscarAtendimentosFila();
    this.buscarFuncionarioPeloCargo();
  },
  methods: {
    buscarAtendimentosFila() {
      fila.getAll().then(res => {
        this.users = res.data;
      });
    },
    recebeDateTimeERetornaSomenteODate(dateTime) {
      return moment(dateTime).format("YYYY-MM-DD");
    },
    recebeDateTimeERetornaSomenteOTime(dateTime) {
      return moment(dateTime).format("HH:mm:ss");
    },
    cadastrarAtendimento() {
      if (
        this.idSelectedMedico == "" ||
        this.cpf == "" ||
        this.grauEmergencia == ""
      ) {
        console.error(
          "Preencha o Campo CPF, e selecione o medico e o grau de Emergencia"
        );
        return;
      }
      this.getIdPaciente();
    },
    mudarStatusAtendimento(atendimento) {
      var obj = {
        filaId: atendimento.filaId,
        id: atendimento.id,
        pacienteId: atendimento.pacienteId,
        medicoId: atendimento.medicoId,
        grauDeEmergencia: atendimento.grauDeEmergencia,
        dataChegada: atendimento.dataChegada,
        statusDeAtendimento: !atendimento.statusDeAtendimento
      };
      fila.put(obj).then(res => {
        this.buscarAtendimentosFila();
      });
    },
    getIdPaciente() {
      paciente.getByCpf(this.cpf).then(res => {
        this.pacienteId = res.data.id;
        this.postFilaAtendimento();
      });
    },
    postFilaAtendimento() {
      let data = new Date();
      let data2 = new Date(data.valueOf() - data.getTimezoneOffset() * 60000);
      var obj = {
        pacienteId: this.pacienteId,
        medicoId: this.idSelectedMedico,
        grauDeEmergencia: this.grauEmergencia,
        dataChegada: data2,
        statusDeAtendimento: false
      };
      fila.post(obj).then(res => {
        this.buscarAtendimentosFila();
      });
    },
    buscarFuncionarioPeloCargo() {
      funcionario.getbyCargo("Médico").then(res => {
        this.medicos = res.data;
      });
    }
  }
};
</script>
<style scoped>
.md-card.md-theme-default {
  display: table;
}
.switch {
  display: right;
}
</style>
