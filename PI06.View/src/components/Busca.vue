<template>
  <div id="app">
      <b-navbar type="dark" variant="dark">
        <b-navbar-nav>
          <router-link to='/home'>Home</router-link>
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
          <label class="active" for="pesquisa"></label>
          <div class="buton"> 
            <b-button variant="primary" @click.prevent="buscarFuncionariosPeloCPF">Buscar</b-button>
          </div>
        </div>    
      {{ resultados }}
    </div>
  </div>
</template>

<script>
  import paciente from '../../services/paciente'
  export default {
    data () {
      return {
        text: '',
        cpfUsuario: null,
        resultados: []
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
    },
    toPage (route) {
      this.$router.push(route)
    }
  }
</script>

<style>
.caixa{
  padding-top: 10%;
}

.buton{
  width: 100%;
}
</style>