import DashboardLayout from "@/pages/Layout/DashboardLayout.vue";

import ListaEspera from "@/pages/ListaEspera.vue";
import Usuario from "@/pages/Usuario.vue";

import Notifications from "@/pages/Notifications.vue";
import Consulta from "@/pages/NewConsulta.vue";

import CadastroPessoa from "@/pages/UserProfile/CadastroPessoaForm.vue"
const routes = [
  {
    path: "/",
    component: DashboardLayout,
    redirect: "/listaespera",
    children: [
      {
        path: "listaespera",
        name: "Lista de Espera",
        component: ListaEspera
      },
      {
        path: "consulta",
        name: "Consulta",
        component: Consulta
      },
      {
        path: "usuario",
        name: "Usuarios",
        component: Usuario
      },
      {
        path: "notifications",
        name: "Notificaçoes",
        component: Notifications
      },
      {
        path: "cadastropessoa",
        name: "cadastropessoa",
        component: CadastroPessoa
      },

    ]
  }
];

export default routes;
