<template>
    <div class="mt-5 panel panel-default container col-6 border border-secondary-subtle shadow p-3 mb-5 bg-body-tertiary rounded">
        <div class="panel-body">
            <div class="row">
                <h3 class="text-center mt-3">VENDEDOR - {{ vendedor.id }} </h3>
            </div>
            <hr />
            <div class="row">
                <p><strong>Nome:</strong> {{ vendedor.nome }}</p>
                <p><strong>Login:</strong> {{ vendedor.login }}</p>
            </div>
        </div>
    </div>
    <div class="ps-0 container col-6">
        <router-link class="btn btn-primary mt-2 mb-2" to="/vendedor/listar">Voltar</router-link>
    </div>
</template>

<script>
import VendedorDataService from '../../services/VendedorDataService';

export default {
    data() {
        return {
            vendedor: {}
        }
    },
    methods: {
        obterVendedor(id) {
            VendedorDataService.obterPorId(id).then((response) => {
                this.vendedor = response.data;
            });
        },
    },
    mounted() {
        this.obterVendedor(this.$route.params.id);
    }
}
</script>