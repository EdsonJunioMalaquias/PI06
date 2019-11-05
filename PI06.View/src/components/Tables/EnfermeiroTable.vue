<template>
  <div>
    <md-table v-model="users" :table-header-color="tableHeaderColor">
      <md-table-row slot="md-table-row" slot-scope="{ item }">
        <md-table-cell md-label="ID">{{ item.id }}</md-table-cell>
        <md-table-cell md-label="Data COntratacao">{{ item.dataContratacao }}</md-table-cell>
        <md-table-cell md-label="Nome">{{ item.nomeEnfermeiro }}</md-table-cell>
        <md-table-cell md-label="Sobrenomes">{{ item.sobrenomeEnfermeiro }}</md-table-cell>
        <md-table-cell md-label="CPF">{{ item.CPF }}</md-table-cell>
         <md-table-cell md-label="RG">{{ item.RG }}</md-table-cell>
        <md-table-cell md-label="SUS">{{ item.sus }}</md-table-cell>
        <md-table-cell md-label="email">{{ item.email }}</md-table-cell>
        <md-table-cell md-label="logradouro">{{ item.logradouro }}</md-table-cell>
        <md-table-cell md-label="numero">{{ item.numero }}</md-table-cell>
        <md-table-cell md-label="bairro">{{ item.bairro }}</md-table-cell>
        <md-table-cell md-label="cidade">{{ item.cidade }}</md-table-cell>
        <md-table-cell md-label="uf">{{ item.uf }}</md-table-cell>
        <md-table-cell md-label="cep">{{ item.cep }}</md-table-cell>
        <md-table-cell md-label="telefone">{{ item.telefone }}</md-table-cell>


        
      </md-table-row>
    </md-table>
  </div>
</template>

<script>
export default {
  name: "enfermeiro-table",
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
          dataContratacao: "",
          nomeEnfermeiro: "Robson",
          sobrenomeEnfermeiro: "nunes",
          CPF: "12345678910",
          RG: "MG-102030",
          sus:"SUS-1020515",
          Email: "robson@unipam.edul.br",
          logradouro: "sda",
          numero: "250",
          bairro: "centro",
          cidade: "Guimarania",
          uf: "MG",
          cep: "38730-000",
          telefone: "999488954"
          
        },
        {
          id: 2,
          dataContratacao: "",
          nomeEnfermeiro: "Robson",
          sobrenomeEnfermeiro: "nunes",
          CPF: "12345678910",
          RG: "MG-102030",
          sus:"SUS-1020515",
          Email: "robson@unipam.edul.br",
          logradouro: "sda",
          numero: "250",
          bairro: "centro",
          cidade: "Guimarania",
          uf: "MG",
          cep: "38730-000",
          telefone: "999488954"
          
        },
        {
          id: 3,
          dataContratacao: "",
          nomeEnfermeiro: "Robson",
          sobrenomeEnfermeiro: "nunes",
          CPF: "12345678910",
          RG: "MG-102030",
          sus:"SUS-1020515",
          Email: "robson@unipam.edul.br",
          logradouro: "sda",
          numero: "250",
          bairro: "centro",
          cidade: "Guimarania",
          uf: "MG",
          cep: "38730-000",
          telefone: "999488954"
          
        }
        
      ]
    };
  }
};
</script>
