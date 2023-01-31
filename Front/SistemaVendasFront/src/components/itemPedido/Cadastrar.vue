<template>
<div>
    <h3 class="text-center">CADASTRAR ITEM DO PEDIDO</h3>
    <div class="form" style="padding: 1%;">
        <div class="container col-8">

            <div>
                <label class="form-label">N° do Pedido</label>
                <div class="input-group mb-3">
                    <input type="text" required v-model="itemPedido.pedidoId" class="form-control" aria-label="Text input with dropdown button">
                    <button class="btn btn-outline-secondary dropdown-toggle" type="button"  data-bs-toggle="dropdown" aria-expanded="false">
                        ID's DISPONÍVEIS
                    </button>
                    <ul class="dropdown-menu">
                        <option class="dropdown-item" v-for="(pedido, index) in pedidos" :key="index" :value="pedido.id">
                            {{ pedido.id }}
                        </option>
                    </ul>
                </div>
            </div>

            <div>
                <label class="form-label">Id do serviço: </label>
                <div class="input-group mb-3">
                    <input type="text" required v-model="itemPedido.servicoId"  class="form-control" aria-label="Text input with dropdown button">
                    <button class="btn btn-outline-secondary dropdown-toggle" type="button"  data-bs-toggle="dropdown" aria-expanded="false">
                        SERVIÇOS DISPONÍVEIS
                    </button>
                    <ul class="dropdown-menu">
                        <option class="dropdown-item" v-for="(servico, index) in servicos" :key="index" :value="servico.id">
                            {{ servico.id }} - {{ servico.nome }}
                        </option>
                    </ul>
                </div>
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
</div>

</template>

<script>
import ItemPedidoDataService from '../../services/ItemPedidoDataService';
import PedidoDataService from '../../services/PedidoDataService';
import ServicoDataService from '../../services/ServicoDataService';

export default {
    data() {
        return {
            itemPedido: {
                pedidoId: "",
                servicoId: "",
                quantidade: "",
                valor: ""
            },
            pedidos: [],
            servicos: []
        };
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
                this.$router.push("listar");
            });
        },
        obterPedidos() 
        {
            PedidoDataService.listar()
                .then(response => {
                    this.pedidos = response.data;
                });
        },
        obterServicos() 
        {
            ServicoDataService.listar()
                .then(response => {
                    this.servicos = response.data;
                });
        }
    },
    mounted(){
        this.obterPedidos();
        this.obterServicos();
    }
}
</script>