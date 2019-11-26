<template>
  <form>
    <md-card>
      <md-card-header :data-background-color="dataBackgroundColor">
        <h4 class="title">Cadastro de Pessoas</h4>
        <p class="category">Prencha os Campos a baixo</p>
      </md-card-header>

      <md-card-content>
        <div class="md-layout">
          <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <h4 class="title">Dados Pessoais</h4>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Nome</label>
              <md-input v-model="nome" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-50 md-size-50">
            <md-field>
              <md-datepicker v-model="dataNascimento">
                <label>Data Nascimento</label>
              </md-datepicker>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>RG</label>
              <md-input v-model="rg" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Cpf</label>
              <md-input v-model="cpf" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <label>Endereco de Email</label>
              <md-input v-model="enderecoEmail" type="email"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Logradouro</label>
              <md-input v-model="logradouro" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Complemento</label>
              <md-input v-model="complemento" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Número</label>
              <md-input v-model="numeroResidencia" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-autocomplete v-model="selectedCidade" :md-options="cidades">
              <label>Cidade</label>
            </md-autocomplete>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-autocomplete v-model="selectedUF" :md-options="uf">
              <label>Unidade Federativa</label>
            </md-autocomplete>=
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

          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>CEP</label>
              <md-input v-model="cep" type="number"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-autocomplete v-model="selectCargo" :md-options="cargo">
              <label>Cargo</label>
            </md-autocomplete>
          </div>
          <div class="md-layout-item md-size-100 text-right">
            <md-button class="md-raised md-success">Nova Cadastro</md-button>
          </div>
        </div>
      </md-card-content>
    </md-card>
  </form>
</template>

<script>
export default {
  name: "cadastro-pessoa-form",
  props: {
    dataBackgroundColor: {
      type: String,
      default: ""
    }
  },
  data: () => ({
    isFuncionario: false,
    isCargoSaude: false,
    selectedCidade: null,
    selectedUF: null,
    selectCargo: null,

    nome: "",
    dataNascimento: null,
    idade: "",
    rg: "",
    cpf: "",
    enderecoEmail: "",
    logradouro: "",
    complemento: "",
    numeroResidencia: "",
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
    Cadastrar() {
      var pessoa = this.cadastrarPessoa;
      if (this.isFuncionario) {
        this.cadastrarFuncionario(pessoa);
      } else {
        this.CadastrarPaciente(pessoa);
      }
    },
    cadastrarPessoa() {
      var obj = {
        nome: this.nome,
        dataNascimento: this.dataNascimento,
        rg: this.rg,
        sus: this.sus,
        codigoCpf: this.cpf,
        enderecoEmail: this.enderecoEmail,
        logradouro: this.logradouro,
        complemento: this.complemento,
        numeroEndereco: this.numeroResidencia,
        bairro: this.bairro,
        cidade: this.selectedCidade,
        uf: this.selectedUF,
        numeroTelefone: this.numeroTelefone,
        ddd: this.ddd,
        cep: this.cep
      };
      return obj;
    },
    CadastrarPaciente(obj) {
      //this.$set(this.someObject, 'b', 2)
      console.log(obj);
    },
    cadastrarFuncionario(obj) {
      console.log(obj);
    }
  }
};
</script>

<style></style>