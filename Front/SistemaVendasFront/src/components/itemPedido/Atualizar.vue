<template>
    <h3 class="text-center">ATUALIZAR ITEM DO PEDIDO</h3>

    <div class="form" style="padding: 1%;">
        <div class="container col-8">
            <div>
                <label class="form-label">Id</label>
                <input type="text" disabled v-model="itemPedido.id" class="form-control">
            </div>
            <div>
                <label class="form-label">N° do Pedido</label>
                <input type="number" disabled v-model="itemPedido.pedidoId" class="form-control">
            </div>
            <div>
                <label class="form-label">Serviço: </label>
                <input type="number" required v-model="itemPedido.servicoId" class="form-control">
            </div>
            <div>
                <label class="form-label">Quantidade: </label>
                <input type="number" required v-model="itemPedido.quantidade" class="form-control">
            </div>
            <div>
                <label class="form-label">Valor: </label>
                <input type="number" format="currency" precision="2" required v-model="itemPedido.valor"
                    class="form-control">
            </div>
            <button class="btn btn-danger" @click="atualizarItemPedido" style="margin-top: 4%">Atualizar</button>
        </div>
    </div>
</template>

<script>
import ItemPedidoDataService from '../../services/ItemPedidoDataService';

export default {
    data() {
        return {
            itemPedido: {},
        }
    },
    methods: {
        obterItemPedido(id) {
            ItemPedidoDataService.obterPorId(id)
                .then((response) => {
                    this.itemPedido = response.data;
                });
        },
        atualizarItemPedido() {
            var idPedido = this.itemPedido.pedidoId
            ItemPedidoDataService.atualizar(this.itemPedido.id, this.itemPedido)
                .then(() => {
                    this.$router.push('/pedido/'+ idPedido + '/itemPedido/listar')
                });
        }
    },
    beforeMount() {
        this.obterItemPedido(this.$route.params.id);
    }
}
</script>