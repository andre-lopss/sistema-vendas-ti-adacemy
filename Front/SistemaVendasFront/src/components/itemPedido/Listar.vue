<template>
    <h3 class="text-center">LISTAGEM DE ITENS DOS PEDIDOS</h3>

    <div class="container col-8">
        <hr />
        <table class="table table-striped">
            <thead class="bg-primary thead-dark">
                <tr>
                    <th scope="col">Id</th>
                    <th scope="col">Pedido</th>
                    <th scope="col">Serviço</th>
                    <th scope="col">Quantidade</th>
                    <th scope="col">Valor</th>
                    <th scope="col" class="text-center">Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(itemPedido, pedido, servico, index) in itensPedidos" :key="index">
                    <td>{{ itemPedido.id }}</td>
                    <td>{{ itemPedido.pedido.id }}</td>
                    <td>{{ itemPedido.servico.id }}</td>
                    <td>{{ itemPedido.quantidade }}</td>
                    <td>{{ itemPedido.valor }}</td>
                    <td class="d-flex justify-content-between">
                        <button class="btn btn-success" @click="editarItemPedido(itemPedido.id)">Editar</button>
                        <button class="btn btn-danger" @click="excluirItemPedido(itemPedido)">Excluir</button>
                    </td>
                </tr>
            </tbody>
        </table>
        <router-link class="btn btn-danger" to="/itemPedido/cadastrar">Cadastrar Item Pedido</router-link>
    </div>
</template>

<script>

import ItemPedidoDataService from '../../services/ItemPedidoDataService';
export default {
    data() {
        return {
            itensPedidos: []
        }
    },
    methods: {
        obterItensPedidos() 
        {
            ItemPedidoDataService.listar()
                .then(response => {
                    this.itensPedidos = response.data;
                });
        }, 
        editarItemPedido(id){
            this.$router.push('/itemPedido/' + id);
        },
        async excluirItemPedido(itemPedido){
            if(confirm(`Tem certeza que deseja excluir o item do pedido N°: ${itemPedido.id}?`)){
                await ItemPedidoDataService.deletar(itemPedido.id);
                this.obterItensPedidos();
            }
        }
    },
    mounted(){
        this.obterItensPedidos();
    }
}
</script>