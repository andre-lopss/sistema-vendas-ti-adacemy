<template>
    <h3 class="text-center">LISTAGEM DE ITENS DOS PEDIDOS</h3>

    <div class="col-7 d-flex flex-column align-items-center">
    <!-- <h2>Pedido {{ pedido.id }} - {{ pedido.vendedor.nome }} - {{ pedido.cliente.nome }}</h2> -->
    <p v-if="itensPedido.length === 0">Esse pedido não possui nenhum item</p>
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
          <tr v-for="(itemPedido, index) in itensPedido" :key="index">
            <th scope="row">{{ itemPedido.id }}</th>
            <td scope="row">{{ itemPedido.servico.nome }}</td>
            <td>{{ itemPedido.valor }}</td>
            <td>{{ itemPedido.quantidade }}</td>
            <td>
              <button class="btn btn-success" @click="editarPedido(pedido.id, itemPedido.id)">Editar</button>
              <button class="btn btn-danger" @click="excluirPedido(item)">Excluir</button>
            </td>
          </tr>
        </tbody>
    </table>
    <button class="btn btn-primary" @click="adicionarNovoItem(pedido.id)">Adicionar novo item</button>
  </div>
</template>

<script>

import ItemPedidoDataService from '../../services/ItemPedidoDataService'
import PedidoDataService from '../../services/PedidoDataService'

export default {
  data() {
    return{
      itensPedido: [],
      pedido: {}
    }
  },
  methods: {
    obterItensPedido() {
      ItemPedidoDataService.listarPorPedido(this.$route.params.id)
        .then(response => this.itensPedido = response.data)
    },
    obterPedidos() {
      PedidoDataService.obterPorId(this.$route.params.pedidoId)
        .then(response => this.pedido = response.data)
    },
    editarPedido(id){
      this.$router.push(`/pedido/:pedidoId/itemPedido/atualizar/` + id)
    },
    async excluirPedido(pedido){
      if(confirm(`Tem certeza que deseja excluir o pedido ${pedido.id}`)){
        await ItemPedidoDataService.deletar(pedido.id)
        this.$router.push("/pedido/listar")
      }
    },
    adicionarNovoItem(idPedido, IdItem){
      this.$router.push("/pedido/"+idPedido+"/itemPedido/atualizar/"+IdItem)
    }
  },
  beforeMount(){
    this.obterItensPedido()
    this.obterPedidos()
  }
}
</script>