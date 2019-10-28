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

        
        <b-table striped hover :items="items">
            <template v-slot:cell(status)="row">
               <b-form-checkbox v-model="checked" switch size="lg" >
                    <div v-if="checked === true">
                    Atendido
                    </div>
                    <div v-else>
                    Não Atendido
                    </div>
                </b-form-checkbox>
            </template>
        </b-table>
    </div> 
</template>

<script>
export default {
    data() {
      return {
          checked: false,
          items: [
          { Nome: '-',
            Data_de_Nascimento: '-', 
            CPF: '-', 
            Medico: '-', 
            Data_Chegada: '-',
            Hora_Chegada: '-',
            Status:''
            }
        ]
      }
    }  
}
</script>

<style>
.fila{
    text-align: center;
}
th{
    width: 10%;
}
td{
    text-align:center;
}

</style>