<template>
  <div>
    <md-table v-model="users" :table-header-color="tableHeaderColor">
      <md-table-row slot="md-table-row" slot-scope="{ item }">
        <md-table-cell md-label="ID">{{ item.id }}</md-table-cell>
        <md-table-cell md-label="Nome">{{ item.Nome }}</md-table-cell>
        <md-table-cell md-label="Data de Nascimento">{{ item.Data_de_Nascimento }}</md-table-cell>
        <md-table-cell md-label="CPF">{{ item.CPF }}</md-table-cell>
        <md-table-cell md-label="Medico">{{ item.Medico }}</md-table-cell>
        <md-table-cell md-label="Data de Chegada">{{ item.Data_Chegada }}</md-table-cell>
        <md-table-cell md-label="Hora de Chegada">{{ item.Hora_Chegada }}</md-table-cell>
        <md-table-cell md-label="Grau de Emergencia">{{ item.Grau_de_Emergencia }}</md-table-cell>
        <md-table-cell md-label="Status">{{ item.Status }}
          <input type="checkbox">
        </md-table-cell>
        
      </md-table-row>
    </md-table>
  </div>
</template>

<script>
export default {
  name: "ordered-table",
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
          name: "Sandro Matias",
          salary: "$36,738",
          country: "Niger",
          city: "Oud-Turnhout"
        },
        {
          id: 2,
          name: "Minerva Hooper",
          salary: "$23,738",
          country: "Curaçao",
          city: "Sinaai-Waas"
        },
        {
          id: 3,
          name: "Sage Rodriguez",
          salary: "$56,142",
          country: "Netherlands",
          city: "Overland Park"
        },
        {
          id: 4,
          name: "Philip Chaney",
          salary: "$38,735",
          country: "Korea, South",
          city: "Gloucester"
        }
      ]
    };
  }
};
</script>
