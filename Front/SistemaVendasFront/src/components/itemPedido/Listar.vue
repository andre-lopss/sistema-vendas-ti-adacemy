<template>
    <h3 class="text-center">LISTAGEM DE ITENS DOS PEDIDOS</h3>

    <div class="col-7 d-flex flex-column align-items-center">
    <!-- <h2>Pedido {{ pedido.id }} - {{ pedido.vendedor.nome }} - {{ pedido.cliente.nome }}</h2> -->
    <p v-if="ItensPedido.length === 0">Esse pedido não possui nenhum item</p>
    <table class="table table-striped" v-else>
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Serviço</th>
            <th scope="col">Valor</th>
            <th scope="col">Quantidade</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(itemPedido, servico,  index) in ItensPedido" :key="index">
            <th scope="row">{{ itemPedido.id }}</th>
            <td scope="row">{{ itemPedido.pedidoId }}</td>
            <td>{{ itemPedido.valor }}</td>
            <td>{{ itemPedido.quantidade }}</td>
            <td>
              <button class="btn btn-success" @click="editarItemPedido(itemPedido.id)">Editar</button>
              <button class="btn btn-danger" @click="excluirItemPedido(itemPedido)">Excluir</button>
            </td>
          </tr>
        </tbody>
    </table>
    <router-link class="btn btn-primary" to="/pedido/listar">Voltar</router-link>
  </div>
</template>

<script>

import ItemPedidoDataService from '../../services/ItemPedidoDataService';
import PedidoDataService from '../../services/PedidoDataService.js';
export default {
  name: "listarItemPedidos",
  data() {
    return{
      ItensPedido: [],
      pedido: {}
    }
  },
  methods: {
    obterItensPedido() {
      ItemPedidoDataService.listarPorPedido(this.$route.params.pedidoId)
        .then(response => this.ItensPedido = response.data)
    },
    obterPedidos(pedidoId) {
      PedidoDataService.obterPorId(pedidoId)
        .then(response => this.Pedido = response.data)
    },
    editarItemPedido(id){
      this.$router.push('/itemPedido/' + id);
    },

    async excluirItemPedido(itemPedido){
        if(confirm(`Tem certeza que deseja excluir o item do pedido N°: ${itemPedido.id}?`)){
          await ItemPedidoDataService.deletar(itemPedido.id);
          this.obterItensPedidos();
        }
    },
  },
  beforeMount(){
    this.obterItensPedido()
    this.obterPedidos(this.$route.params.id)
  }
}
</script>