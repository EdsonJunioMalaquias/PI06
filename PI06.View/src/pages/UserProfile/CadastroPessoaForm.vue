<template>
  <div id="app">
    <div class="container">
      <md-card>
        <md-card-header data-background-color="green">
          <h4 class="title">Cadastro de Pessoas</h4>
        </md-card-header>

        <md-card-content>
          <div class="md-layout">
            <div class="md-layout-item md-small-size-100 md-size-100">
              <br />
              <h4 class="title">Dados Pessoais</h4>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-40">
              <md-field>
                <label>Nome</label>
                <md-input v-model="nome" type="text"></md-input>
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-50 md-size-20">
              <md-datepicker v-model="dataNascimento">
                <label>Data Nascimento</label>
              </md-datepicker>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-40">
              <md-field>
                <label>Endereço de Email</label>
                <md-input v-model="enderecoEmail" type="email"></md-input>
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-33">
              <md-field>
                <label>RG</label>
                <md-input v-model="rg" type="text"></md-input>
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-33">
              <md-field>
                <label>CPF</label>
                <md-input v-model="cpf" type="text"></md-input>
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-34">
              <md-field>
                <label>SUS</label>
                <md-input v-model="sus" type="text"></md-input>
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-33">
              <md-field>
                <label>Logradouro</label>
                <md-input v-model="logradouro" type="text"></md-input>
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-10">
              <md-field>
                <label>Número</label>
                <md-input v-model="numeroResidencia" type="text"></md-input>
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-23">
              <md-field>
                <label>Bairro</label>
                <md-input v-model="bairro" type="text"></md-input>
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-33">
              <md-field>
                <label>Complemento</label>
                <md-input v-model="complemento" type="text"></md-input>
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-33">
              <md-autocomplete v-model="selectedCidade" :md-options="cidades">
                <label>Cidade</label>
              </md-autocomplete>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-33">
              <md-autocomplete v-model="selectedUF" :md-options="uf">
                <label>Estado</label>
              </md-autocomplete>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-33">
              <md-field>
                <label>CEP</label>
                <md-input v-model="cep" type="number"></md-input>
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-10">
              <md-field>
                <label>DDD</label>
                <md-input v-model="ddd" type="text"></md-input>
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-40">
              <md-field>
                <label>Número de Telefone</label>
                <md-input v-model="numeroTelefone" type="number"></md-input>
              </md-field>
            </div>
            <div class="md-layout-item md-small-size-100 md-size-40"></div>
            <div class="md-layout">
              <div class="md-layout-item md-small-size-100 md-size-100">
                <div v-if="isFuncionario">
                  <md-switch class="switch" v-model="isFuncionario">Cadastrar Funcionario</md-switch>
                </div>
                <div v-else>
                  <md-switch class="switch" v-model="isFuncionario">Cadastrar Paciente</md-switch>
                </div>
              </div>
              <div v-if="isFuncionario" class="md-layout-item md-small-size-100 md-size-30">
                <md-autocomplete v-model="selectCargo" :md-options="cargo">
                  <label>Cargo</label>
                </md-autocomplete>
              </div>
              <div
                class="md-layout"
                v-if="selectCargo != null && selectCargo != ''&& selectCargo !='Recepcionista'"
              >
                <div v-if="isFuncionario" class="md-layout-item md-small-size-100 md-size-30">
                  <md-field>
                    <label>Descrição do Conselho</label>
                    <md-input v-model="descricaoConselho" type="text"></md-input>
                  </md-field>
                </div>
                <div v-if="isFuncionario" class="md-layout-item md-small-size-100 md-size-30">
                  <md-field>
                    <label>Número do Conselho</label>
                    <md-input v-model="numeroConselho" type="number"></md-input>
                  </md-field>
                </div>
              </div>
            </div>
            <div class="md-layout-item md-size-100 text-right">
              <md-button @click="cadastrar()" class="md-raised md-success">Novo Cadastro</md-button>
            </div>
          </div>
        </md-card-content>
      </md-card>
      <md-snackbar
        md-position="center"
        :md-duration="duracao"
        :md-active.sync="showSnackbar"
        md-persistent
      >
        <span>{{ error }}</span>
        <md-button class="md-primary" @click="showSnackbar = false">Fechar</md-button>
      </md-snackbar>
    </div>
  </div>
</template>

<script>
import funcionario from "../../../services/funcionario";
import paciente from "../../../services/paciente";

import moment from "moment";
export default {
  name: "cadastro-pessoa-form",
  data: () => ({
    obj1: { name: "obj1" },
    obj2: { name: "obj2" },
    isFuncionario: false,
    selectedCidade: null,
    selectedUF: null,
    selectCargo: null,

    showSnackbar: false,
    error: "Erro Inesperado!",
    duracao: 4000,

    nome: "",
    dataNascimento: null,
    rg: "",
    cpf: "",
    enderecoEmail: "",
    logradouro: "",
    complemento: "",
    numeroResidencia: "",
    bairro: "",
    cep: "",
    sus: "",
    ddd: "",
    numeroTelefone: "",

    numeroConselho: "",
    descricaoConselho: "",

    cidades: [
      "Patos de Minas",
      "Guimarania",
      "Belo Horizonte",
      "Presidente Olegario",
      "Carmo do Paranaiba"
    ],
    uf: ["MG"],
    cargo: ["Medico", "Recepcionista", "Enfermeiro"]
  }),
  methods: {
    recebeDateTimeERetornaSomenteODate(dateTime) {
      return moment(dateTime).format("YYYY-MM-DD");
    },
    validador() {
      if (
        this.nome == null ||
        this.nome == "" ||
        this.dataNascimento == null ||
        this.dataNascimento == "" ||
        this.rg == null ||
        this.rg == "" ||
        this.sus == null ||
        this.sus == "" ||
        this.cpf == null ||
        this.cpf == "" ||
        this.enderecoEmail == null ||
        this.enderecoEmail == "" ||
        this.logradouro == null ||
        this.logradouro == "" ||
        this.numeroResidencia == null ||
        this.numeroResidencia == "" ||
        this.bairro == null ||
        this.bairro == "" ||
        this.selectedCidade == null ||
        this.selectedCidade == "" ||
        this.selectedUF == null ||
        this.selectedUF == "" ||
        this.numeroTelefone == null ||
        this.numeroTelefone == "" ||
        this.ddd == null ||
        this.ddd == "" ||
        this.cep == null ||
        this.cep == ""
      ) {
        return false;
      }
      return true;
    },
    cadastrar() {
      console.log(this.recebeDateTimeERetornaSomenteODate(this.dataNascimento));
      if (!this.validador()) {
        this.error = "Preencha todos os campos!";
        this.showSnackbar = true;
        return;
      }
      var pessoa = {
        nome: this.nome,
        dataNascimento: this.recebeDateTimeERetornaSomenteODate(this.dataNascimento),
        rg: this.rg,
        sus: this.sus,
        codigoCpf: this.cpf,
        enderecoEmail: this.enderecoEmail,
        logradouro: this.logradouro,
        complemento: this.complemento,
        numeroEndereco: this.numeroResidencia,
        bairro: this.bairro,
        cidade: this.selectedCidade,
        uf: 13,
        numeroTelefone: this.numeroTelefone,
        ddd: this.ddd,
        cepCod: this.cep
      };
      
      if (this.isFuncionario) {
        this.cadastrarFuncionario(pessoa);
      } else {
        this.CadastrarPaciente(pessoa);
      }
    },
    CadastrarPaciente(obj) {
      var pessoaPaciente = {pessoa:{}}
      Object.assign(pessoaPaciente.pessoa, obj);
      paciente
        .post(pessoaPaciente)
        .then(res => {
          this.error = "Cadastro efetuado com sucesso!";
          this.showSnackbar = true;
        })
        .catch(err => {
          this.error = err.message;
          this.showSnackbar = true;
        });
    },
    		
    cadastrarFuncionario(obj) {
      var pessoaFuncionario = {pessoa:{}}
      Object.assign(teste3.pessoa, obj);
      if (this.selectCargo == null || this.selectCargo == "") {
        this.error = "Selecione um cargo valido!";
        this.showSnackbar = true;
        return;
      }
      if (this.selectCargo == "Medico") {
        if (
          this.numeroConselho == null ||
          this.numeroConselho == "" ||
          this.descricaoConselho == null ||
          this.descricaoConselho == ""
        ) {
          this.error = "Preencha a descrição do conselho e o número!";
          this.showSnackbar = true;
          return;
        }

        Object.assign(obj, {
          conselho: {
            numeroConselho: this.numeroConselho,
            descricaoConselho: this.descricaoConselho
          }
        });
        this.$set(obj, "cargoId", 5);
      } else if (this.selectCargo == "Enfermeiro") {
        if (
          this.numeroConselho == null ||
          this.numeroConselho == "" ||
          this.descricaoConselho == null ||
          this.descricaoConselho == ""
        ) {
          this.error = "Preencha a descrição do conselho e o número!";
          this.showSnackbar = true;
          return;
        }

        Object.assign(obj, {
          conselho: {
            numeroConselho: this.numeroConselho,
            descricaoConselho: this.descricaoConselho
          }
        });
        this.$set(obj, "cargoId", 6);
      } else if (this.selectCargo == "Recepcionista") {
        this.$set(obj, "cargoId", 7);
      }


      return;
      funcionario
        .post(obj)
        .then(res => {
          this.error = "Cadastro efetuado com sucesso!";
          this.showSnackbar = true;
        })
        .catch(err => {
          this.error = err.message;
          this.showSnackbar = true;
        });
    }
  }
};
</script>

<style></style>