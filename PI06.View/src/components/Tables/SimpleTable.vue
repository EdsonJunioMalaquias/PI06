<template>
  <div>
    <md-table v-model="users" :table-header-color="tableHeaderColor">
      <md-table-row slot="md-table-row" slot-scope="{ item }">
        <md-table-cell md-label="Nome">{{ item.name }}</md-table-cell>
        <md-table-cell md-label="Sobrenome">{{ item.sobrenome }}</md-table-cell>
        <md-table-cell md-label="sus">{{ item.sus }}</md-table-cell>
        <md-table-cell md-label="cpf">{{ item.cpf }}</md-table-cell>
      </md-table-row>
    </md-table>
  </div>
</template>

<script>
export default {
  name: "simple-table",
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
          name: "Sandrao ",
          sobrenome: "rice",
          sus: "2134321",
          cpf: "11111111111"
        },
        {
          name: "Sandrao ",
          sobrenome: "rice",
          sus: "2134321",
          cpf: "11111111111"
        },
         {
          name: "keva ",
          sobrenome: "rice",
          sus: "2134321",
          cpf: "22222222222"
        },
         {
          name: "lucas ",
          sobrenome: "rice",
          sus: "2134321",
          cpf: "3333333333"
        },
        {
          name: "robson ",
          sobrenome: "rice",
          sus: "2134321",
          cpf: "11111111111"
        }
       
      ]
    };
  }
};
</script>
