<template>

    <h3 class="container col-10">Resumo do Pedido</h3>
    <div class="panel panel-default container col-10" style="border: 1px solid grey ;">
        <div class="panel-body">
            <div class="row">
                <div class="col-12">
                    <h3>Nº do Pedido: {{ itemPedido.pedidoId }} </h3>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-3">
                    <h3>Seus Dados</h3>
                    <div>
                        <!-- <p><strong>Vendedor - {{ pedido.vendedor }}</strong></p> --> 
                        <p>Nome: {{ itemPedido.pedido.vendedorId }}</p> 
                        <!-- <p>Login: {{ pedido.vendedor.login }}</p>
                        <p><strong>Cliente - {{ pedido.clienteId }}</strong></p>
                        <p>Nome: {{ pedido.cliente.nome }}</p>
                        <p>Login: {{ pedido.cliente.login }}</p> -->
                    </div>
                </div>
                <div class="col-3">
                    @Model.Cadastro.Email
                </div>
                <div class="col-6">
                    <h3>Serviço</h3>
                    <div>{{ itemPedido.servico.nome }}</div>
                    <div>{{ itemPedido.servico.descricao }}</div>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-8">
                    <h3>Item</h3>
                    {{ itemPedido.id }}
                </div>
                <div class="col-4">
                    <h3>Quantidade</h3>
                </div>
            </div>

            <div class="row" v-fo>
                <div class="col-10">
                </div>
                <div class="col-2">
                    <div class="pull-right">{{ itemPedido.quantidade }}</div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>

import ItemPedidoDataService from '../../services/ItemPedidoDataService';
import PedidoDataService from '../../services/PedidoDataService';

export default {
    data() {
        return {
            pedido: {},
            itemPedido: {}
        }
    },
    methods: {
        obterPedido(id) {
            PedidoDataService.obterPorId(id)
                .then((response) => {
                    this.pedido = response.data;
                    
                });
        },
        obterItemPedido(id) {
            ItemPedidoDataService.obterPorId(id)
                .then((response) => {
                    this.itemPedido = response.data;

                });
        },

    },
    beforeMount() {
        this.obterPedido(this.$route.params.id);
        this.obterItemPedido(this.$route.params.id);
    }
}
</script>
