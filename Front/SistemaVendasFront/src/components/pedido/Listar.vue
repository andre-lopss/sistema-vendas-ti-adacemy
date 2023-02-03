<template>
    <link rel="stylesheet"
        href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200" />

    <h3 class="text-center" style="margin-top: 10px;">LISTAGEM DE PEDIDOS</h3>

    <hr />

    <div class="container col-7">
        <router-link class="btn btn-success" to="/pedido/cadastrar" style="margin-bottom: 10px;">Cadastrar
            Pedido</router-link>

        <table class="table table-striped">
            <thead class="bg-dark thead-dark fonteColor">
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
                    <th>{{ pedido.id }}</th>
                    <td>{{ obterData(pedido.data) }}</td>
                    <td>{{ pedido.vendedor.nome }}</td>
                    <td>{{ pedido.cliente.nome }}</td>
                    <td>
                        <div class="btn-group btn-group-toggle container" data-toggle="buttons">

                            <button class="btn btn-dark" @click="editarPedido(pedido.id)">Editar</button>

                            <button style="font-size: 1rem; border-radius: 0px;"
                                class="btn btn-success dropdown-toggle " type="button" data-bs-toggle="dropdown"
                                aria-expanded="false">
                                Itens Pedido
                            </button>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" @click="buscarItensPedido(pedido.id)">Listar</a></li>
                                <li><a class="dropdown-item" @click="cadastrarItemPedido(pedido.id)">Cadastrar</a>
                                </li>
                            </ul>

                            <button class="btn btn-danger" @click="excluirPedido(pedido)">Excluir</button>

                            <button type="button"
                                class="btn btn-secondary d-flex justify-content-center align-items-center"
                                @click="resumoPedido(pedido.id)">
                                <svg style="padding-right: 5px;" xmlns="http://www.w3.org/2000/svg" width="16"
                                    height="16" fill="currentColor" class="bi bi-file-earmark-font-fill"
                                    viewBox="0 0 16 16">
                                    <path
                                        d="M9.293 0H4a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V4.707A1 1 0 0 0 13.707 4L10 .293A1 1 0 0 0 9.293 0zM9.5 3.5v-2l3 3h-2a1 1 0 0 1-1-1zM5.057 6h5.886L11 8h-.5c-.18-1.096-.356-1.192-1.694-1.235l-.298-.01v5.09c0 .47.1.582.903.655v.5H6.59v-.5c.799-.073.898-.184.898-.654V6.755l-.293.01C5.856 6.808 5.68 6.905 5.5 8H5l.057-2z" />
                                </svg>
                                Resumo
                            </button>
                        </div>
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
        },
        obterData(data) {
            let dataPedido = new Date(data);
            return dataPedido.toLocaleString();
        }
    },
    mounted() {
        this.obterPedidos();
    }
}
</script>