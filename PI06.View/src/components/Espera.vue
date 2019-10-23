<template>
    <div id="app">
        <b-navbar toggleable="lg" type="dark" variant="info">
            <b-navbar-brand router-link to='/home'>Home</b-navbar-brand>

            <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
            <!-- Right aligned nav items -->
            <b-navbar-nav class="ml-auto">
                <b-button variant="dark" @click.prevent="buscarFuncionariosPeloCPF" router-link to='/busca'>Adicionar Pacientes</b-button>
            </b-navbar-nav>
        </b-navbar>

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

<style>

</style>