<template>
  <h3 class="text-center" style="margin-top: 10px;">ITENS DO PEDIDO {{ pedido.id }}</h3>
  <hr />
  <div class="container col-5">
    <p v-if="ItensPedido.length === 0" class="text-center">
      Esse pedido não possui nenhum item
    </p>
    <table class="table table-striped" v-else>
      <thead class="bg-dark thead-dark fonteColor">
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
          <td>{{ itemPedido.valor.toLocaleString("pt-br", {style: 'currency', currency: 'BRL'}) }}</td>
          <td>{{ (itemPedido.valor * itemPedido.quantidade).toLocaleString("pt-br", {style: 'currency', currency: 'BRL'}) }}</td>
          <td>
            <div class="btn-group btn-group-toggle container" data-toggle="buttons">
              <button class="btn btn-secondary" @click="editarItemPedido(itemPedido.id)">Editar</button>
              <button class="btn btn-danger" @click="excluirItemPedido(itemPedido)">Excluir</button>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
    <router-link class="btn btn-primary" to="/pedido/listar" style="margin-right: 10px;">Voltar</router-link>
    <button class="btn btn-success" @click="cadastrarItemPedido(pedido.id)">Adicionar Item</button>
  </div>
</template>

<script>
import ItemPedidoDataService from '../../services/ItemPedidoDataService';
import PedidoDataService from '../../services/PedidoDataService.js';

export default {
  data() {
    return {
      ItensPedido: [],
      pedido: {}
    }
  },
  methods: {
    cadastrarItemPedido(id) {
      this.$router.push('/pedido/' + id + '/itemPedido/cadastrar')
    },
    editarItemPedido(id) {
      this.$router.push('/itemPedido/' + id);
    },
    obterItensPedido() {
      ItemPedidoDataService.listarPorPedido(this.$route.params.pedidoId).then(response => this.ItensPedido = response.data)
    },
    obterPedidos() {
      PedidoDataService.obterPorId(this.$route.params.pedidoId).then(response => this.pedido = response.data)
    },
    resumoPedido(id) {
      this.$router.push('/ItemPedido/resumo/' + id);
    },
    async excluirItemPedido(itemPedido) {
      if (confirm(`Tem certeza que deseja excluir o item do pedido N°: ${itemPedido.id}?`)) {
        await ItemPedidoDataService.deletar(itemPedido.id);
        this.obterItensPedido();
      }
    },
  },
  beforeMount() {
    this.obterItensPedido();
    this.obterPedidos(this.$route.params.id);
  }
}
</script>