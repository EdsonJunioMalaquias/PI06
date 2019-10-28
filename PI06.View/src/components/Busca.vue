<template>
  <div id="app">
      <b-navbar type="dark" variant="info">
        <b-navbar-nav>
          <b-nav-item router-link to='/home'>Home</b-nav-item>
        </b-navbar-nav>
      </b-navbar>  
      
      <div class="container">

        <div class="caixa">

          <h4>Pesquisar Paciente:</h4>

          <b-form-input id="pesquisa" 
                        type="text" 
                        v-model="cpfUsuario" 
                        class="validate" 
                        placeholder="Digite o CPF" 
                        v-mask="'###.###.###-##'">
          </b-form-input>

          <div class="buton"> 
            <b-button variant="primary" @click.prevent="buscarFuncionariosPeloCPF">Buscar</b-button>
            <b-button class="button2" variant="primary" @click="disabled = (disabled + 1) % 2" >Adicionar</b-button>
          </div>

        </div>    
      </div>

      <div id="container2" class="container">          
        <div class="row">
            <div class="col-md">
                <form>
                    <input type="text"  placeholder="Nome" :disabled="disabled == 0 ? true : false">
                    <label>Nome</label>

                    <input type="date"  placeholder="Data de Nascimento" :disabled="disabled == 0 ? true : false">
                    <label>Data de Nascimento</label>

                    <input type="text"  placeholder="CPF" :disabled="disabled == 0 ? true : false">
                    <label>CPF</label>

                    <b-container class="bv-example-row">
                      <b-row>
                        <b-col>
                          <label>Medico</label>
                          <b-form-select :options="options"></b-form-select>
                        </b-col>
                        <b-col>
                          <label>Data da Chegada</label>
                          <input type="date" placeholder="Data">
                        </b-col>
                        <b-col>
                          <label>Horas da Chegada</label>
                          <input type="time" placeholder="horas">
                        </b-col>
                        <b-col>
                          <label>Grau de Emergenica</label>
                          <b-form-select :options="options2"></b-form-select>
                        </b-col>
                      </b-row>
                    </b-container>
                    <b-button router-link to='/espera' class="waves-effect waves-light btn-small buton" variant="primary">Adicionar Paciente a Fila</b-button>
                </form>
            </div>          
        </div>
      </div>
  </div>
</template>

<script>
  import paciente from '../../services/paciente'
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