<template>
    <h3 class="text-center">CADASTRAR ITEM DO PEDIDO</h3>

    <div class="form" style="padding: 1%;">
        <div class="container col-8">
            <div>
                <label class="form-label">N° do Pedido</label>
                <input type="number" required v-model="itemPedido.pedidoId" class="form-control">
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
                <input type="number" format="currency" precision="2" required v-model="itemPedido.valor" class="form-control">
            </div>
            <button class="btn btn-danger" @click="cadastrarItemPedido" style="margin-top: 4%">Cadastrar</button>
        </div>
    </div>
</template>

<script>
import ItemPedidoDataService from '../../services/ItemPedidoDataService';

export default {
    data() {
        return {
            itemPedido: {
                pedidoId: '',
                servicoId: '',
                quantidade: '',
                valor: ''
            }
        }
    },
    methods: {
        cadastrarItemPedido() {
            var data = {
                pedidoId: this.itemPedido.pedidoId,
                servicoId: this.itemPedido.servicoId,
                quantidade: this.itemPedido.quantidade,
                valor: this.itemPedido.valor
            };
            ItemPedidoDataService.cadastrar(data)
                .then(() => {
                    this.$router.push('listar');
                });

        }
    }
}
</script>