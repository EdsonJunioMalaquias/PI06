<template>
  <div id="app">
      
      <div class="container">

        <div class="caixa">

          <h4>Pesquisar Paciente:</h4>

          <md-field>
            <label for="pesquisa">Pesquisar CPF</label>
            <md-input id="pesquisa" 
                        type="text" 
                        v-model="cpfUsuario" 
                        class="validate"
                        v-mask="'###.###.###-##'"></md-input>
          </md-field>

          <div class="buton">
            <md-button @click.prevent="buscarFuncionariosPeloCPF" class="md-raised md-success">
              Buscar
            </md-button> 
            <md-button class="button2 md-raised md-success" v-if="disabled==0" @click="disabled = (disabled + 1) % 2" >Adicionar</md-button>
            <md-button class="button2 md-raised md-success" v-if="disabled==1" @click="disabled = (disabled + 1) % 2" >Cancelar</md-button>
          </div>

        </div>    
      </div>

      <div id="container2" class="container">          
        <div class="row">
            <div class="col-md">
                <form>
                    <h4>Cadastrar Paciente:</h4>

                    <md-field>
                      <label for="Nome">Nome</label>
                      <md-input type="text" id="Nome" :disabled="disabled == 0 ? true : false"></md-input>
                    </md-field>

                    <md-datepicker v-model="selectedDate" :disabled="disabled == 0 ? true : false">
                      <label :disabled="disabled == 0 ? true : false">Data de Nascimento</label>
                    </md-datepicker>
                    
                    <md-field>
                      <label for="CPF">CPF</label>
                      <md-input type="text" id="CPF" :disabled="disabled == 0 ? true : false"></md-input>
                    </md-field>

                    <div class="md-layout">
                      <div class="md-layout-item">
                        <md-field>
                          <label for="medico">Medico</label>
                          <md-select name="medico" id="medico">
                            <md-option value="M1">Medico1</md-option>
                            <md-option value="M2">Medico2</md-option>
                            <md-option value="M3">Medico3</md-option>
                            <md-option value="M4">Medico4</md-option>
                            <md-option value="M5">Medico5</md-option>
                          </md-select>
                        </md-field>
                      </div>
                      <div class="md-layout-item">
                        <md-field>
                          <label for="DataChegada">Data da Chegada</label>
                          <md-input type="date" id="DataChegada"></md-input>
                        </md-field>
                      </div>
                      <div class="md-layout-item">
                        <md-field>
                          <label for="HoradaChegada">Hora da Chegada</label>
                          <md-input type="time" id="HoradaChegada"></md-input>
                        </md-field>
                      </div>
                      <div class="md-layout-item">
                        <md-field>
                          <label for="GrauEmergencia">Grau de Emergência</label>
                          <md-select name="GrauEmergencia" id="GrauEmergencia">
                            <md-option value="M1">Emergência</md-option>
                            <md-option value="M2">Muito Urgente</md-option>
                            <md-option value="M3">Urgente</md-option>
                            <md-option value="M4">Pouco Urgente</md-option>
                            <md-option value="M5">Não Urgente</md-option>
                          </md-select>
                        </md-field>
                      </div>
                    </div>
                    <md-button class="md-raised md-success buton">Adicionar Paciente a Fila</md-button>
                </form>
            </div>          
        </div>
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
        options: [
          { value: null, text: 'Medico 1' },
          { value: 'a', text: 'Medico 2' },
          { value: 'b', text: 'Medico 3' },
          { value: 'c', text: 'Medico 4' },
          { value: 'd', text: 'Medico 5', disabled: true }
        ],
        options2: [
          { value: null, text: 'Vermelho' },
          { value: 'a', text: 'Laranja' },
          { value: 'b', text: 'Amarelo' },
          { value: 'c', text: 'Verde' },
          { value: 'd', text: 'Azul'}
        ]
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