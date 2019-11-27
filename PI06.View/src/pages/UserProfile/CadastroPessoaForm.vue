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
                <br>
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
                <md-input v-model="complemento" type="text"></md-input>
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
            <div class="md-layout-item md-small-size-100 md-size-40">
      
            </div>
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
                class="md-layout" v-if="selectCargo != null && selectCargo != ''&& selectCargo !='Recepcionista'"
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
    </div>
  </div>
</template>

<script>
export default {
  name: "cadastro-pessoa-form",
  data: () => ({
    obj1: {name: 'obj1'},
    obj2: {name: 'obj2'},
    isFuncionario: false,
    isCargoSaude: false,
    selectedCidade: null,
    selectedUF: null,
    selectCargo: null,

    nome: "",
    dataNascimento: null,
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
      let pessoa = this.cadastrarPessoa;
      console.log(pessoa);
      if (this.isFuncionario) {
        this.cadastrarFuncionario(pessoa);
      } else {
        this.CadastrarPaciente(pessoa);
      }
    },
    cadastrarPessoa() {
      let obj = {
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