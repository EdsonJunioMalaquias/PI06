<template>
  <div id="app">
    <div class="shadow-sm p-3 mb-5 bg-white rounded">
      <div>
        <h1 class="titulo">Login</h1>
        <br>
        <label class="label">Usuario:</label>
        <input type="text" class="form-control" placeholder="Digite o seu usuario">
        <br>
        <label class="label">Senha:</label>
        <input type="password" class="form-control" placeholder="Digite sua senha">
        <br>
        <b-button class="button" variant="primary">Entrar</b-button>
      </div>
    </div>        
  </div>    
</template>

<script>
export default {
    data() {
      return {
      }
    }
}      
</script>


<style scoped>
.form-control{
  margin-left: 25px;
  height: 45px;
  width: 90%;
}
.rounded{
  margin-top: 7%;
  display: auto;
  width: 41%;
  height: 450px;
  margin-left: 29%;
}
.button{
  margin-top: 5%;
  border-radius: 27px !important;
  width: 30%;
  height: 50px;
  margin-left: 65%;
}
.label{
  margin-left: 25px;
}
.titulo{
  margin-left: 25px;
  margin-top: 20px;
}
</style>
