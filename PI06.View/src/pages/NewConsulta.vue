<template>
  <div class="content">
    
      <div class="md-layout">
        <div class="md-layout-item md-small-size-50 md-size-100">
          <md-card>
          <md-card-header data-background-color="green">
            <h4 class="title">Pesquisar Pacientes</h4>
            <p class="category">Buscar Pacientes pelo CPF</p>
          </md-card-header>
          <md-card-content>
            <md-field>
              <label for="pesquisa">Digite o CPF</label>
              <md-input
                id="pesquisa"
                type="text"
                v-model="cpfUsuario"
                class="validate"
                v-mask="'###.###.###-##'"
              ></md-input>
            </md-field>
            <div class="buton">
              <md-button
                @click.prevent="buscarPacientePeloCPF()"
                class="md-raised md-success"
              >Buscar</md-button>
            </div>
          </md-card-content>
          </md-card>
        </div>
      </div>
    
    <br />
    <br />
    <div class="md-layout">
      <div class="md-layout-item md-small-size-50 md-size-40">
        <div>
          <form>
            <md-card>
              <md-card-header data-background-color="green">
                <h4 class="title">Dados Pessoais</h4>
                <p class="category">Prencha os Campos a baixo</p>
              </md-card-header>
              <md-card-content>
                <md-field>
                  <label for="Nome">Nome</label>
                  <md-input type="text" id="Nome" readonly :value="resultadosPessoais.nome" />
                </md-field>
                <md-field>
                  <label for="sus">SUS:</label>
                  <md-input type="number" id="sus" readonly :value="resultadosPessoais.sus" />
                </md-field>
                <md-field>
                  <label>Idade</label>
                  <md-input type="number" readonly :value="idade">></md-input>
                </md-field>
                <hr />

                <h5>Dados Nova Consulta</h5>

                <md-field>
                  <label>Observações</label>
                  <md-textarea v-model="observacao" required maxlength="100" />
                  <span class="md-error">Preencha a Observações!</span>
                </md-field>

                <md-field>
                  <label>Exames</label>
                  <md-select v-model="idTipoExame">
                    <md-option
                      v-for="item in this.ListaExames"
                      :key="item.id"
                      :value="item.id"
                    >{{ item.descricao }}</md-option>
                  </md-select>
                </md-field>

                <md-field>
                  <label>Resultado</label>
                  <md-input type="text" placeholder="Resultado" v-model="resultado" required />
                  <span class="md-error">Campo Obrigatorio!</span>
                </md-field>

                <md-button
                  v-on:click.prevent="AdicionarExame()"
                  class="md-raised md-success"
                >Adcionar Exame</md-button>
                <br />
                <br />
                <h4>Exames Incluidos</h4>
                <ul>
                  <li v-for="item in exames" :key="item.id">
                    {{ item.id }} - {{ item.resultado }} -
                    <span
                      @click.prevent="RemoverExame(item.id)"
                    >Remover -</span>
                    <span @click.prevent="EditarExame(item.id, item.resultado)">Editar</span>
                  </li>
                </ul>

                <md-button
                  @click.prevent="CadastrarConsulta()"
                  class="md-raised md-success"
                >Cadastrar Consulta</md-button>

                <md-snackbar
                  md-position="center"
                  :md-duration="duracao"
                  :md-active.sync="showSnackbar"
                  md-persistent
                >
                  <span>{{ error }}</span>
                  <md-button class="md-primary" @click="showSnackbar = false">Fechar</md-button>
                </md-snackbar>
              </md-card-content>
            </md-card>
          </form>
        </div>
      </div>
      <div class="md-layout-item md-medium-size-100 md-size-60">
        <md-card md-with-hover>
          <md-ripple>
            <md-card-header data-background-color="green">
              <h4 class="title">Histórico</h4>
            </md-card-header>

            <md-card-content>
              <div class="search-wrapper">
                <input type="text" v-model="search" placeholder="Search title.." />
                <label>Search title:</label>
              </div>

              <div>
                <div class="card-style" v-for="item of filteredList" :key="item.id">
                  <div v-for="procedimento of item.procedimentos" :key="procedimento.id">
                    <div class="md-title">{{ procedimento.tipoProcedimento.descricao }}</div>
                    <h4>{{ procedimento.tipoProcedimento.descricao }}</h4>
                    <div>
                      <p>Médico:{{ item.funcionarioMedico.pessoa.nome }}</p>
                      <br />
                    </div>
                    <p>
                      Observações:{{ procedimento.observacao }}
                      <br />
                    </p>
                    <md-table name="Exame">
                      <md-table-row>
                        <md-table-head>Descrição</md-table-head>
                        <md-table-head>Resultado</md-table-head>
                        <md-table-head>Resultado Referência</md-table-head>
                      </md-table-row>
                      <md-table-row>
                        <md-table-cell>{{ procedimento.exame.tipoExame.descricao }}</md-table-cell>
                        <md-table-cell>{{ procedimento.exame.resultado }}</md-table-cell>
                        <md-table-cell>{{ procedimento.exame.tipoExame.resultadoReferencia }}</md-table-cell>
                      </md-table-row>
                    </md-table>
                  </div>
                  <md-card-actions>
                    <md-button>Editar</md-button>
                    <md-button>Excluir</md-button>
                  </md-card-actions>
                </div>
              </div>
            </md-card-content>
          </md-ripple>
        </md-card>
      </div>
    </div>
  </div>
</template>

<script>
import paciente from "../../services/paciente";
import tipoExame from "../../services/tipoExame";
import consulta from "../../services/consulta";
import procedimento from "../../services/procedimento";
import exame from "../../services/exame";
import funcionario from "../../services/funcionario";

export default {
  mounted() {
    this.ListarTipoExame();
    this.dateNow = new Date();
  },
  computed: {
    imc: function() {
      return this.peso == 0 || this.altura == 0
        ? 0
        : parseFloat(this.peso / Math.pow(this.altura, 2)).toFixed(2);
    },
    filteredList() {
      return this.resultadosConsultas.filter(consuta => {
        return consuta.funcionarioMedico.pessoa.nome
          .toLowerCase()
          .includes(this.search.toLowerCase());
      });
    }
  },
  data() {
    return {
      search: "",
      showSnackbar: false,
      error: "Erro Inesperado!",
      duracao: 4000,
      medicoiD: 1004,
      medicos: [],
      cpfUsuario: "",
      idTipoProcedimento: 1,
      resultadosPessoais: {},
      resultadosConsultas: [],
      ListaExames: [],
      idTipoExame: 0,
      resultado: "",
      dateNow: "",
      idade: 0,
      /*peso: 0,
				altura:0,
				protManchester: 0,
				precao:0,
				batcardia:0,*/
      textarea: "",
      exames: [],
      observacao: ""
    };
  },
  methods: {
    AdicionarExame() {
      this.exames.push({
        resultado: this.resultado,
        id: this.idTipoExame
      });
    },
    RemoverExame(id) {
      this.exames.splice(this.exames.indexOf(id), 1);
    },
    EditarExame(id, resultado) {
      this.resultado = resultado;
      this.idTipoExame = id;
    },

    buscarPacientePeloCPF() {
      paciente
        .getByCpf(this.cpfUsuario)
        .then(res => {
          this.resultadosPessoais = res.data.pessoa;
          this.resultadosConsultas = res.data.consultas;
          this.calculaIdade();
          res.data.consultas.forEach(element => {
            this.buscarMedicos(element.idFuncionarioMedico);
          });
        })
        .catch(err => {
          this.error = err.message;
          this.showSnackbar = true;
        });
    },
    buscarMedicos(id) {
      funcionario
        .getbById(id)
        .then(res => {
          this.medicos = res.data.pessoa;
        })
        .catch(err => {
          this.error = err.message;
          this.showSnackbar = true;
        });
    },
    calculaIdade() {
      var dataNasc = new Date(this.resultadosPessoais.dataNascimento);
      var currentDate = new Date();
      var currentYear = currentDate.getFullYear();
      var birthdayThisYear = new Date(
        currentYear,
        dataNasc.getMonth(),
        dataNasc.getDate()
      );
      this.idade = currentYear - dataNasc.getFullYear();
      if (birthdayThisYear > currentDate) {
        this.idade--;
      }
    },
    ListarTipoExame() {
      tipoExame.getAll().then(res => {
        this.ListaExames = res.data;
      });
    },
    CadastrarConsulta() {
      var obj = {
        idPaciente: this.resultadosPessoais.id,
        idFuncionarioMedico: this.medicoiD,
        dataInicio: this.dateNow,
        dataTermino: new Date()
      };
      consulta.post(obj).then(res => {
        this.cadastrarProcedimento(res.data.id);
      });
    },
    cadastrarProcedimento(idConsulta) {
      var obj = {
        observacao: this.observacao,
        idConsulta: idConsulta,
        idTipoProcedimento: this.idTipoProcedimento
      };
      procedimento.post(obj).then(res => {
        this.cadastrarExame(res.data.id);
      });
    },
    cadastrarExame(idProcedimentoExame) {
      this.exames.forEach(element => {
        var obj = {
          resultado: element.resultado,
          idTipoExame: element.id,
          iD: idProcedimentoExame
        };
        exame.post(obj);
      });
      this.buscarPacientePeloCPF();
    },
    toPage(route) {
      this.$router.push(route);
    }
  }
};
</script>

<style>
.card-style {
  width: 100%;
  height: 200px;
  margin: 8px;
  background: rgb(230, 230, 230);
  border-radius: 10px;
  font-family: monospace;
  overflow-y: scroll;
  text-align: justify;
  padding: 10px;
}
textarea {
  height: 10rem;
  width: 100%;
}
.caixa{
  padding-top: 3%;
}
.buton{
  margin-top: 20px;
}
.button2{
  margin-left: 20px;
}
#container2{
  margin-top: 2%;
}

</style>
<style lang="scss" scoped>
.md-card {
  width: 100%;
  margin: 4px;
  display: inline-block;
  vertical-align: top;
}
.md-field {
  max-width: 300px;
}
</style>
