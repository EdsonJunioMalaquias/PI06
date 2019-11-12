<template>
  <div>
    <md-table v-model="users" :table-header-color="tableHeaderColor">
      <md-table-row slot="md-table-row" slot-scope="{ item }">
        <md-table-cell md-label="ID">{{ item.id }}</md-table-cell>
        <md-table-cell md-label="Nome">{{ item.pessoa.nome }}</md-table-cell>
        <md-table-cell md-label="Email">{{ item.pessoa.enderecoEmail }}</md-table-cell>
        <md-table-cell md-label="CPF">{{ item.pessoa.codigoCpf }}</md-table-cell>
         <md-table-cell md-label="RG">{{ item.pessoa.rg }}</md-table-cell>
        <md-table-cell md-label="CRM">{{ item.conselho.numeroConselho }}</md-table-cell>
        
      </md-table-row>
    </md-table>
  </div>
</template>

<script>
import funcionario from "../../../services/funcionario.js"
export default {
  name: "medico-table",
  props: {
    tableHeaderColor: {
      type: String,
      default: ""
    }
  },
  mounted(){
			this.buscarFuncionarioPeloCargo();
	},
  data() {
    return {
      selected: [],
      users: []
    };

  },
  methods :{
    buscarFuncionarioPeloCargo () {
				funcionario.getbyCargo("Médico")
					.then((res) => {
						this.users = res.data						
					})
				},
  }
};
</script>
