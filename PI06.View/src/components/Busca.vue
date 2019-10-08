<template>
  <div id="app">

    <div class="container">

      <form>

        <div class="caixa">

            

          <h4>Pesquisar Paciente:</h4>
            
          <div class="row">
            <div class="input-field col s6">
              <input id="pesquisa" type="text" v-model="cpfUsuario" class="validate" placeholder="Digite o CPF" mask="'###.###.###-##'">

              <label class="active" for="pesquisa"></label>
            </div>
          </div>

          <button class="waves-effect waves-light btn-small" @click.prevent="buscarFuncioariosPeloCPF">Buscar</button>
        
        </div>
      </form>

      {{ resultados }}

    </div>

  </div>
</template>

<script>
  import paciente from '../../services/paciente'
  export default {
    data () {
      return {
        cpfUsuario: null,
        resultados: []
      }
    },
    methods: {
      buscarFuncioariosPeloCPF () {
        paciente.listar(this.cpfUsuario)
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
  padding-top: 15%;
}
</style>