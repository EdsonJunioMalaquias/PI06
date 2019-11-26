<template>
  <form>
    <md-card>
      <md-card-header :data-background-color="dataBackgroundColor">
        <h4 class="title">Consulta</h4>
        <p class="category">Preencha os Campos a baixo</p>
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
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-field>
              <label>Cartão SUS</label>
              <md-input v-model="sus" type="email"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-50">
            <md-autocomplete v-model="selectedIdade" :md-options="idade">
            <label>Idade</label>
            </md-autocomplete>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <h4 class="title"> Histórico</h4>
              
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <label>Descrição</label>
              <md-input v-model="Peso" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <label>Resultado</label>
              <md-input v-model="Peso" type="text"></md-input>
            </md-field>
          </div>
          <div class="md-layout-item md-small-size-100 md-size-100">
            <md-field>
              <label>Resultado Referência</label>
              <md-input v-model="Peso" type="text"></md-input>
            </md-field>
          </div>
          
          <div class="md-layout-item md-size-100 text-right">
            <md-button class="md-raised md-success">Nova consulta</md-button>
          </div>
        </div>
      </md-card-content>
    </md-card>
  </form>
</template>
<script>
 /* import paciente from '../../../services/paciente' */
export default {
  name: "edit-profile-form",
  props: {
    dataBackgroundColor: {
      type: String,
      default: ""
    }
  },
    data: () => ({
      selectedIdade: null,
      idade: [
        '01',
        '02',
        '03',
        '04',
        '05'
        
      ]
      
    })
  /* mounted(){
            this.buscarPacientePeloCPF ();
        },
  data() {
    return {
       textError: '',
                cpfUsuario: 90790162091,
                resultadosPessoais: {},
                resultadosConsultas: [],
                idade: 20
    };
  },
   methods: {
        buscarPacientePeloCPF () {
            paciente.getByCpf(this.cpfUsuario)
                .then((res) => {
                    console.log('resultado da API => ', res.data.consultas)
                    this.resultadosPessoais = res.data
                    this.resultadosConsultas = res.data.consultas
                })
                .catch((err) => {
                    console.error('erro ao buscar na API =>', err)
                })
            },

        },*/  
};
</script>
<style></style>
