<template>
  <div id="app">
    <Busca/>
  </div>
</template>

<script>
import Login from './components/Login.vue'
import Busca from './components/Busca.vue'

export default {
  name: 'app',
  components: {
    Busca

  }
}
</script>

<style>
/*body{
  background-image: url("fundo5.jpg");
  
}*/

#app {
  font-family: sans-serif, Raleway-Regular;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  
}
</style>
