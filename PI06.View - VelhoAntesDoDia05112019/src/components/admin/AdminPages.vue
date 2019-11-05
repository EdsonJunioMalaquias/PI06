<template>
    <div class="admin-pages">
        <PageTitle icon="fa fa-cogs" main="Administração do Sistema"
            sub="Controle" />
        <div class="admin-pages-tabs">
            <b-card no-body>
                <b-tabs card>
                    <b-tab title="Medicos" active>
                        <MedicoAdmin />
                    </b-tab>
                    <b-tab title="Enfermeiros">
                        <EnfermeiroAdmin />
                    </b-tab>
                    <b-tab title="Recepcionistas">
                        <RecepcionistaAdmin />
                    </b-tab>
                    <b-tab title="Administrador">
                        <UsuarioAdmin />
                    </b-tab>
                    <b-tab title="Novo">
                        <nnovoAdmin/>
                    </b-tab>
                    
                </b-tabs>
            </b-card>
        </div>
    </div>
</template>

<script>
import PageTitle from '../template/PageTitle'
import MedicoAdmin from './MedicoAdmin'
import EnfermeiroAdmin from './EnfermeiroAdmin'
import RecepcionistaAdmin from './RecepcionistaAdmin'
import UsuarioAdmin from './UsuarioAdmin'

export default {
    name: 'AdminPages',
    components: { PageTitle, MedicoAdmin, EnfermeiroAdmin, RecepcionistaAdmin, UsuarioAdmin }
}
</script>

<style>

</style>
