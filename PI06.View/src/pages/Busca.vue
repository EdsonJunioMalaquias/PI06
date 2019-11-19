<template>
  <div id="app">
    <div class="container">
      <md-card>

        <md-card-header data-background-color="green">
          <h4 class="title">Pesquisar Pacientes</h4>
          <p class="category">Buscar Pacientes pelo CPF</p>
        </md-card-header>

        <md-card-content>

          <md-field>
            <label for="pesquisa">Digite o CPF</label>
            <md-input id="pesquisa" 
                      type="text" 
                      v-model="cpfUsuario" 
                      class="validate"
                      v-mask="'###.###.###-##'">
            </md-input>
          </md-field>

          <div class="buton">
            <md-button @click.prevent="buscarFuncionariosPeloCPF" class="md-raised md-success">
              Buscar
            </md-button> 
            <md-button class="button2 md-raised md-success" v-if="disabled==0" @click="disabled = (disabled + 1) % 2" >Adicionar</md-button>
            <md-button class="button2 md-raised md-success" v-if="disabled==1" @click="disabled = (disabled + 1) % 2" >Cancelar</md-button>
          </div>
          
        </md-card-content>

      </md-card>       
    </div>

    <div class="container" v-if="disabled==1">                        
      <md-card>

        <md-card-header data-background-color="green">
          <h4 class="title">Adicionar Pacientes</h4>
          <p class="category">Adicionar Pacientes Manualmente</p>
        </md-card-header>

        <md-card-content>
          
          <md-field>
            <label for="Nome">Nome</label>
            <md-input type="text" id="Nome"></md-input>
          </md-field>

          <md-datepicker v-model="selectedDate">
            <label>Data de Nascimento</label>
          </md-datepicker> 

          <md-field>
            <label for="CPF">CPF</label>
            <md-input type="text" v-model="CPF" id="CPF" v-mask="'###.###.###-##'"></md-input>
          </md-field>

          <div class="md-layout">
            <div class="md-layout-item">
              <md-field>
                <label for="medico">Medico</label>
                <md-select name="medico" id="medico">
                  <md-option value="M1">Medico1</md-option>
                </md-select>
              </md-field>
            </div>

            <div class="md-layout-item">
              <md-field>
                <label for="GrauEmergencia">Grau de Emergência</label>
                <md-select name="GrauEmergencia" id="GrauEmergencia">
                  <md-option value="1">Emergência</md-option>
                  <md-option value="2">Muito Urgente</md-option>
                  <md-option value="3">Urgente</md-option>
                  <md-option value="4">Pouco Urgente</md-option>
                  <md-option value="5">Não Urgente</md-option>
                </md-select>
              </md-field>
            </div>

          </div>
          <md-button class="md-raised md-success buton">Adicionar Paciente a Fila</md-button>            
        </md-card-content>
      </md-card>          
    </div>
  </div>
</template>

<script>
 
  export default {
    data () {
      return {
        selectedDate: null,
        disabled: 0,
        text: '',
        cpfUsuario: null,
        resultados: [],
        CPF:""
      }
    },
    methods: {
      buscarFuncionariosPeloCPF () {
        paciente.getByCpf(this.cpfUsuario)
          .then((res) => {
            console.log('resultado da API => ', res)
            this.resultados = res.data
          })
          .catch((err) => {
            console.error('erro ao buscar na API =>', err)
          })
      }
    }
  }
</script>

<style>
.md-list-item-text{
  position:unset !important;
}
</style>