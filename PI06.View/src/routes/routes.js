import DashboardLayout from "@/pages/Layout/DashboardLayout.vue";

import ListaEspera from "@/pages/ListaEspera.vue";
import Consulta from "@/pages/Consulta.vue";
import Usuario from "@/pages/Usuario.vue";
import Busca from "@/pages/Busca.vue";
import Notifications from "@/pages/Notifications.vue";
import novaConsulta from "@/pages/NewConsulta.vue";

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
        path: "/busca",
        name: "Busca",
        component: Busca
      },
      {
        path: "notifications",
        name: "Notificaçoes",
        component: Notifications
      },
      {
        path: 'novaconsulta',
        name: 'NovaConsulta',
        component: novaConsulta
      },
      
    ]
  }
];

export default routes;
