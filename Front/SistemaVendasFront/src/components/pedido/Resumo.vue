<template>
    <h3 class="container col-10 text-center">RESUMO DO PEDIDO</h3>
    <div class="panel panel-default container col-6" style="border: 1px solid grey ;">
        <div class="panel-body">
            <div class="row">
                <div class="col-12">
                    <h3>Nº do Pedido: {{ pedido.id }} </h3>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-12">
                    <h3>Seus Dados</h3>
                    <div class="row">
                        <div class="col-12">
                            <p>Data: {{ obterData(pedido.data) }}</p>
                        </div>
                        <div class="col-6">
                            <p><strong>VENDEDOR - {{ pedido.vendedorId }}</strong></p>
                            <p>Nome: {{ pedido.vendedor.nome }}</p>
                            <p>Login: {{ pedido.vendedor.login }}</p>
                        </div>
                        <div class="col-6">
                            <p><strong>CLIENTE - {{ pedido.clienteId }}</strong></p>
                            <p>Nome: {{ pedido.cliente.nome }}</p>
                            <p>Login: {{ pedido.cliente.login }}</p>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <hr />
                <div class="row">
                    <div class="col-10 container">
                        <h3 class="text-center">Itens</h3>

                        <p v-if="ItensPedido.length === 0" class="text-center">
                            Esse pedido não possui nenhum item
                        </p>
                        <table class="table table-striped" v-else>
                            <thead class="bg-dark thead-dark fonteColor">
                                <tr>
                                    <th scope="col" class="text-center">#</th>
                                    <th scope="col">Serviço</th>
                                    <th scope="col" class="text-center">Quantidade</th>
                                    <th scope="col">Valor unitário</th>
                                    <th scope="col">Sub-Total</th>
                                </tr>
                            </thead>
                            <tbody v-for="(item, index) in ItensPedido" :key="index">
                                <tr>
                                    <th scope="row">{{ item.id }}</th>
                                    <td>{{ item.servico.nome }}</td>
                                    <td class="text-center">{{ item.quantidade }}</td>
                                    <td scope="row">{{
                                        item.valor.toLocaleString("pt-br", {
                                            style: 'currency', currency:
                                                'BRL'
                                        })
                                    }}</td>
                                    <td>R${{ (item.valor * item.quantidade).toLocaleString("pt-br", {
                                        style: 'currency',
                                        currency: 'BRL'
                                    }) }}</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-8">
                    <h3>Quantidade de Itens</h3>
                    <div class="pull-right">{{ ItensPedido.length }}</div>
                </div>
                <div class="col-4">
                    <h3>Total</h3>
                    <div class="pull-right">{{ valorTotal() }}</div>
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
            ItensPedido: [],
        }
    },
    methods: {
        obterPedido(id) {
            PedidoDataService.obterPorId(id)
                .then((response) => {
                    this.pedido = response.data;
                });
        },
        valorTotal() {
            let total = 0;
            this.ItensPedido.forEach(item => {
                total += (item.quantidade * item.valor);
            });
            return total.toLocaleString("pt-br", { style: 'currency', currency: 'BRL' });
        },
        obterItensPedido(id) {
            ItemPedidoDataService.listarPorPedido(id).then(response => this.ItensPedido = response.data)
        },
        buscarItensPedido(id) {
            this.$router.push('/pedido/resumo/' + id + '/itemPedido/listar')
        },
        obterData(data) {
            let dataPedido = new Date(data);
            return dataPedido.toLocaleString();
        }
    },
    beforeMount() {
        this.obterPedido(this.$route.params.id);
        this.obterItensPedido(this.$route.params.id);
    }
}
</script>
