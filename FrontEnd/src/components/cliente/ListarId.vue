<template>
    <div class="mt-5 panel panel-default container col-6 border border-secondary-subtle shadow p-3 mb-5 bg-body-tertiary rounded" >
        <div class="panel-body">
            <div class="row">
                <h3 class="text-center mt-3">CLIENTE - {{ cliente.id }} </h3>
            </div>
            <hr />
            <div class="row">
                <p><strong>Nome:</strong> {{ cliente.nome }}</p>
                <p><strong>Login:</strong> {{ cliente.login }}</p>
            </div>
        </div>
    </div>
    <div class="ps-0 container col-6">
        <router-link class="btn btn-primary mt-2 mb-2" to="/cliente/listar">Voltar</router-link>
    </div>
</template>

<script>
import ClienteDataService from '../../services/ClienteDataService';

export default {
    data() {
        return {
            cliente: {}
        }
    },
    methods: {
        obterCliente(id) {
            ClienteDataService.obterPorId(id).then((response) => {
                this.cliente = response.data;
            });
        },
    },
    mounted() {
        this.obterCliente(this.$route.params.id);
    }
}
</script>