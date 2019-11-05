<template>
  <div>
    <md-table v-model="users" :table-header-color="tableHeaderColor">
      <md-table-row slot="md-table-row" slot-scope="{ item }">
        <md-table-cell md-label="ID">{{ item.id }}</md-table-cell>
        <md-table-cell md-label="Nome">{{ item.Nome }}</md-table-cell>
        <md-table-cell md-label="Sobrenome">{{ item.Sobrenome }}</md-table-cell>
        <md-table-cell md-label="Email">{{ item.Email }}</md-table-cell>
        <md-table-cell md-label="CPF">{{ item.CPF }}</md-table-cell>
         <md-table-cell md-label="RG">{{ item.RG }}</md-table-cell>
        <md-table-cell md-label="CRM">{{ item.CRM }}</md-table-cell>
        
      </md-table-row>
    </md-table>
  </div>
</template>

<script>
export default {
  name: "medico-table",
  props: {
    tableHeaderColor: {
      type: String,
      default: ""
    }
  },
  data() {
    return {
      selected: [],
      users: [
        {
          id: 1,
          Nome: "Sandro ",
          Sobrenome: "Matias",
          Email: "sandro@unipam.edu.br",
          CPF: "11111111111",
          RG: "MG2507195",
          CRM: "MG-552255"
        },
        {
          id: 2,
          Nome: "Lucas",
          Sobrenome: "BRuno",
          Email: "lucas@unipam.edu.br",
          CPF: "22222222222",
          RG: "MG1525165252",
          CRM: "MG21225523"
        },
        {
          id: 3,
          Nome: "Robson",
          Sobrenome: "Nunes",
          Email: "robson@unipam.edu.br",
          CPF: "33333333333",
          RG: "MG4565266",
          CRM: "1231321"
        }
        
      ]
    };
  }
};
</script>
