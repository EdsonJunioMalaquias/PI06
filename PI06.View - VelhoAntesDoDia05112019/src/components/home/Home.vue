<template>
    <div class="home">
        <PageTitle icon="fa fa-home" main="Dashboard"
            sub="Sistema de Gerenciamento de Saude" />

        <div class="home-pages-tabs">
            <b-card no-body>
                <b-tabs card>
                    <b-tab title="fila" active>
                        <ArticleAdmin />
                    </b-tab>
                    <b-tab title="atendidos">
                        <CategoryAdmin />
                    </b-tab>
                    <b-tab title="Usuários">
                        <UserAdmin />
                    </b-tab>
                </b-tabs>
            </b-card>
        </div>    
    </div>
</template>

<script>
import PageTitle from '../template/PageTitle'

export default {
    name: 'Home',
    components: { PageTitle }
    
}
</script>

<style>
    .stats {
        display: flex;
        justify-content: space-between;
        flex-wrap: wrap;
    }
</style>
 