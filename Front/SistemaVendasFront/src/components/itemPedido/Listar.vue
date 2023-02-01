<template>
  <h3 class="text-center">ITENS DO PEDIDO {{ pedido.id }}</h3>

  <div class="container col-8">
  <!-- <h2>Pedido {{ pedido.id }} - {{ pedido.vendedor.nome }} - {{ pedido.cliente.nome }}</h2> -->
  <p v-if="ItensPedido.length === 0" class="text-center">Esse pedido não possui nenhum item</p>
  <table class="table table-striped" v-else>
      <thead class="bg-primary thead-dark">
        <tr>
          <th scope="col">#</th>
          <th scope="col">Serviço</th>
          <th scope="col" class="text-center">Quantidade</th>
          <th scope="col">Valor</th>
          <th scope="col">Sub total</th>
          <th scope="col" class="text-center">Ações</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(itemPedido, index) in ItensPedido" :key="index">
          <th scope="row">{{ itemPedido.id }}</th>
          <td scope="row">{{ itemPedido.servico.nome }}</td>
          <td class="text-center">{{ itemPedido.quantidade }}</td>
          <td>{{ itemPedido.valor }}</td>
          <td>{{ itemPedido.valor * itemPedido.quantidade}}</td>
          <td class="d-flex justify-content-between">
            <button class="btn btn-success" @click="editarItemPedido(itemPedido.id)">Editar</button>
            <button class="btn btn-danger" @click="excluirItemPedido(itemPedido)">Excluir</button>
          </td>
        </tr>
      </tbody>
  </table>
  <router-link class="btn btn-primary" to="/pedido/listar">Voltar</router-link>
  <router-link class="btn btn-danger success" to="/itemPedido/cadastrar">Cadastrar</router-link>
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
    itemPedido: {},
    pedido: {}
  }
},
methods: {
  obterItensPedido() {
    ItemPedidoDataService.listarPorPedido(this.$route.params.pedidoId)
      .then(response => this.ItensPedido = response.data)
  },
  obterItemPedido(id) {
            ItemPedidoDataService.obterPorId(id)
                .then((response) => {
                    this.itemPedido = response.data;
                });
  },
  obterPedidos(pedidoId) {
    PedidoDataService.obterPorId(pedidoId)
      .then(response => this.Pedido = response.data)
  },
  editarItemPedido(id){
    this.$router.push('/itemPedido/' + id);
  },
  cadastrarItemPedido(id){
    this.$router.push('/pedido/'+id+'/itemPedido/cadastrar')
  },
  async excluirItemPedido(itemPedido){
      if(confirm(`Tem certeza que deseja excluir o item do pedido N°: ${itemPedido.id}?`)){
        await ItemPedidoDataService.deletar(itemPedido.id);
        this.obterItensPedidos();
      }
  },
},
beforeMount(){
  this.obterItensPedido();
  this.obterItemPedido(this.$route.params.id);
  this.obterPedidos(this.$route.params.id);
}
}
</script>