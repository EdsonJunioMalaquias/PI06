<template>
  <div id="app">
      <md-navbar type="dark" variant="info">
        <md-navbar-nav>
          <md-nav-item router-link to='/home'>Home</md-nav-item>
        </md-navbar-nav>
      </md-navbar>  
      
      <div class="container">

        <div class="caixa">

          <h4>Pesquisar Paciente:</h4>

          <md-form-input id="pesquisa" 
                        type="text" 
                        v-model="cpfUsuario" 
                        class="validate" 
                        placeholder="Digite o CPF" 
                        v-mask="'###.###.###-##'">
          </md-form-input>

          <div class="buton"> 
            <md-button variant="primary" @click.prevent="buscarFuncionariosPeloCPF">Buscar</md-button>
            <md-button class="button2" variant="primary" @click="disabled = (disabled + 1) % 2" >Adicionar</md-button>
          </div>

        </div>    
      </div>

      <div id="container2" class="container">          
        <div class="row">
            <div class="col-md">
                <form>
                    <h4>Cadastrar Paciente:</h4>

                    <input type="text"  placeholder="Nome" :disabled="disabled == 0 ? true : false">
                    <label>Nome</label>

                    <input type="date"  placeholder="Data de Nascimento" :disabled="disabled == 0 ? true : false">
                    <label>Data de Nascimento</label>

                    <input type="text"  placeholder="CPF" :disabled="disabled == 0 ? true : false">
                    <label>CPF</label>

                    <md-container class="bv-example-row">
                      <md-row>
                        <md-col>
                          <label>Medico</label>
                          <md-form-select :options="options"></md-form-select>
                        </md-col>
                        <b-col>
                          <label>Data da Chegada</label>
                          <input type="date" placeholder="Data">
                        </b-col>
                        <md-col>
                          <label>Horas da Chegada</label>
                          <input type="time" placeholder="horas">
                        </md-col>
                        <md-col>
                          <label>Grau de Emergenica</label>
                          <md-form-select :options="options2"></md-form-select>
                        </md-col>
                      </md-row>
                    </md-container>
                    <md-button router-link to='/espera' class="waves-effect waves-light btn-small buton" variant="primary">Adicionar Paciente a Fila</md-button>
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