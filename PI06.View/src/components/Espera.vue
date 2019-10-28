<template>
    <div id="app" class="fila">
        <b-navbar toggleable="lg" type="dark" variant="info">
            <b-navbar-brand router-link to='/home'>Home</b-navbar-brand>

            <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
            <!-- Right aligned nav items -->
            <b-navbar-nav class="ml-auto">
                <b-button variant="dark" router-link to='/busca'>Adicionar Pacientes</b-button>
            </b-navbar-nav>
        </b-navbar>

        
        <table>
            <tr>
                <th>Nome</th>
                <th>Data de Nascimento</th>
                <th>CPF</th>
                <th>Medico a Atender</th>
                <th>Data Chegada</th>
                <th>Hora Chegada</th>
                <th>Status</th>
            </tr>
            <tr>
                <td>.</td>
                <td>.</td>
                <td>.</td>
                <td>.</td>
                <td>.</td>
                <td>.</td>
                <td>.</td>
            </tr>
            <tr>
                <td>.</td>
                <td>.</td>
                <td>.</td>
                <td>.</td>
                <td>.</td>
                <td>.</td>
                <td>.</td>
            </tr>
            <tr>
                <td>.</td>
                <td>.</td>
                <td>.</td>
                <td>.</td>
                <td>.</td>
                <td>.</td>
                <td>.</td>
            </tr>
        </table>
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
#app{
    text-align: center;
}
th{
    width: 10%;
}
td{
    text-align:center;
}

</style>