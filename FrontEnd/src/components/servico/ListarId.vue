<template>
    <div class="mt-5 panel panel-default container col-6 border border-secondary-subtle shadow p-3 mb-5 bg-body-tertiary rounded">
        <div class="panel-body">
            <div class="row">
                <h3 class="text-center mt-3">SERVIÇO - {{ servico.id }} </h3>
            </div>
            <hr />
            <div class="row">
                <p><strong>Nome:</strong> {{ servico.nome }}</p>
                <p><strong>Descrição:</strong> {{ servico.descricao }}</p>
            </div>
        </div>
    </div>
    <div class="ps-0 container col-6">
        <router-link class="btn btn-primary mt-2 mb-2" to="/servico/listar">Voltar</router-link>
    </div>
</template>

<script>
import ServicoDataService from '../../services/ServicoDataService';

export default {
    data() {
        return {
            servico: {}
        }
    },
    methods: {
        obterServico(id) {
            ServicoDataService.obterPorId(id).then((response) => {
                this.servico = response.data;
            });
        },
    },
    mounted() {
        this.obterServico(this.$route.params.id);
    }
}
</script>