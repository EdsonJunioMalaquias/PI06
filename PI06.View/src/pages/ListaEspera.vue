<template>
  <div class="content">
    <div class="md-layout">
      <div class="md-layout-item md-medium-size-50 md-xsmall-size-50 md-size-50">
        <md-card>
          <md-card-header data-background-color="green">
            <div class="md-layout">
              <h4 class="title">Lista de Espera</h4>
              <md-switch class="switch" v-model="filterValue">Boolean</md-switch>
            </div>
            <p class="category">Paciente</p>
          </md-card-header>
          <md-card-content>
            <div>
              <div v-for="fila of filteredList" :key="fila.id">
                <md-table v-model="fila.atendimentos" :table-header-color="tableHeaderColor">
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
                      @click.prevent="mudarStatusAtendimento(item.statusDeAtendimento)"
                      class="md-raised md-success"
                    >Mudar</md-button>
                  </md-table-row>
                </md-table>
              </div>
            </div>
          </md-card-content>
        </md-card>
      </div>
      <div class="md-layout-item md-small-size-50 md-size-35">
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
                  <md-select name="medico" id="medico">
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
            <md-button
              @click.prevent="cadastrarAtendimento()"
              class="md-raised md-success buton"
            >Adicionar Paciente a Fila</md-button>
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
      if (!this.filterValue) {
        return result;
      }
      const filter = event =>
        event.atendimentos.some(atendimento =>
          atendimento.statusDeAtendimento
            .toString()
            .toLowerCase()
            .includes(this.filterValue.toString().toLowerCase())
        );
      return result.filter(filter);
    }
  },
  data() {
    return {
      users: [],
      filterValue: "",
      dateTime: "",
      cpf: "",
      grauEmergencia: "",
      medicos: []
    };
  },
  mounted() {
    this.buscarAtendimentosFila();
    this.recebeDateTimeERetornaSomenteODate();
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
      var obj = {
        pacienteId: this.getIdPaciente(),
        medicoId: this.medicoiD,
        grauDeEmergencia: this.grauEmergencia,
        dataChegada: this.dateNow,
        statusDeAtendimento: false
      };
      fila.post(obj).then(res => {
        console.log(res);
      });
    },
    mudarStatusAtendimento(statusAtual) {},
    getIdPaciente() {
      paciente.getByCpf(this.cpf).then(res => {
        console.log(res);
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
  float: right;
}
</style>
