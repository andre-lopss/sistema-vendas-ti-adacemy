<template>
    <link rel="stylesheet"
        href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200" />

    <h3 class="text-center" style="margin-top: 10px;">LISTAGEM DE PEDIDOS</h3>

    <hr />
    
    <div class="container col-6">
        <router-link class="btn btn-success" to="/pedido/cadastrar" style="margin-bottom: 10px;">Cadastrar
            Pedido</router-link>

        <table class="table table-striped">
            <thead class="bg-primary thead-dark fonteColor">
                <tr>
                    <th scope="col">Id</th>
                    <th scope="col">Data</th>
                    <th scope="col">Vendedor</th>
                    <th scope="col">Cliente</th>
                    <th scope="col" class="text-center">Ações</th>
                </tr>
            </thead>

            <tbody>
                <tr v-for="(pedido, index) in pedidos" :key="index">
                    <td>{{ pedido.id }}</td>
                    <td>{{ pedido.data }}</td>
                    <td>{{ pedido.vendedor.nome }}</td>
                    <td>{{ pedido.cliente.nome }}</td>
                    <td class="d-flex justify-content-between">

                        <button class="btn btn-primary" @click="editarPedido(pedido.id)">Editar</button>

                        <div class="dropdown">
                            <button style="font-size: 1rem; height: 100%;"
                                class="btn btn-success btn-lg dropdown-toggle" type="button" data-bs-toggle="dropdown"
                                aria-expanded="false">
                                Itens Pedido
                            </button>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" @click="buscarItensPedido(pedido.id)">Listar</a></li>
                                <li><a class="dropdown-item" @click="cadastrarItemPedido(pedido.id)">Cadastrar</a></li>
                            </ul>
                        </div>

                        <button class="btn btn-danger" @click="excluirPedido(pedido)">Excluir</button>

                        <button class="btn btn-default" @click="resumoPedido(pedido.id)">
                            <span class="material-symbols-outlined">
                                picture_as_pdf
                            </span>
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>

import PedidoDataService from '../../services/PedidoDataService';

export default {
    data() {
        return {
            pedidos: []
        }
    },
    methods: {
        editarPedido(id) {
            this.$router.push('/pedido/' + id);
        },
        async excluirPedido(pedido) {
            if (confirm(`Tem certeza que deseja excluir o pedido N°: ${pedido.id}?`)) {
                await PedidoDataService.deletar(pedido.id);
                this.obterPedidos();
            }
        },
        obterPedidos() {
            PedidoDataService.listar().then(response => {
                this.pedidos = response.data;
            });
        },
        resumoPedido(id) {
            this.$router.push('/pedido/resumo/' + id);
        },
        buscarItensPedido(id) {
            this.$router.push('/pedido/' + id + '/itemPedido/listar')
        },
        cadastrarItemPedido(id) {
            this.$router.push('/pedido/' + id + '/itemPedido/cadastrar')
        }
    },
    mounted() {
        this.obterPedidos();
    }
}
</script>