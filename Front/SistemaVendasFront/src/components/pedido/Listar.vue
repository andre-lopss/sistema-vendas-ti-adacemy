<template>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200" />

    <h3 class="text-center">LISTAGEM DE PEDIDOS</h3>

    <div class="container col-8">
        <hr />
        <table class="table table-striped">
            <thead class="bg-primary thead-dark">
                <tr>
                    <th scope="col">Id</th>
                    <th scope="col">Data</th>
                    <th scope="col">Vendedor</th>
                    <th scope="col">Cliente</th>
                    <th scope="col" class="text-center">Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(pedido, cliente, vendedor, index) in pedidos" :key="index">
                    <td>{{ pedido.id }}</td>
                    <td>{{ pedido.data }}</td>
                    <td>{{ pedido.vendedor.id }}</td>
                    <td>{{ pedido.cliente.id }}</td>
                    <td class="d-flex justify-content-between">
                        <button class="btn btn-success" @click="editarPedido(pedido.id)">Editar</button>

                        <button class="btn btn-danger" @click="excluirPedido(pedido)">Excluir</button>

                        <button class="btn btn-default"  @click="resumoPedido">
                            <span class="material-symbols-outlined">
                                picture_as_pdf
                            </span>
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>
        <router-link class="btn btn-danger" to="/pedido/cadastrar">Cadastrar Pedido</router-link>
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
        obterPedidos() 
        {
            PedidoDataService.listar()
                .then(response => {
                    this.pedidos = response.data;
                });
        }, 
        editarPedido(id){
            this.$router.push('/pedido/' + id);
        },
        resumoPedido(id){
            this.$router.push('/pedido/resumo/' + id);
        },
        async excluirPedido(pedido){
            if(confirm(`Tem certeza que deseja excluir o pedido N°: ${pedido.id}?`)){
                await PedidoDataService.deletar(pedido.id);
                this.obterPedidos();
            }
        }
    },
    mounted(){
        this.obterPedidos();
    }
}
</script>