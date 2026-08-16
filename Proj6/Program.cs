Produto[] vetProd = new Produto[10];
int quantidade = 0;
int op = 0;
string BuscarProduto;

do
{
    Cabecalho();
    if(int.TryParse(Console.ReadLine(),out op))
    {
    switch (op)
    {
        case 1:
            quantidade = CadastroProd(quantidade, vetProd);
            break;
        case 2:
            Listar(quantidade, vetProd);
            break;
        case 3:
            Console.WriteLine("Qual o nome do produto que deseja buscar");
            BuscarProduto = Console.ReadLine()!.ToUpper();
            Produto? prods = Buscar(BuscarProduto, quantidade, vetProd);
            if (prods != null)
            {
                prods.ExibirProduto();
                break;
            }
            Console.WriteLine("Produto não encontrado");
            break;
        case 4:
            Console.WriteLine("Digite o nome do Produto: ");
            BuscarProduto = Console.ReadLine()!.ToUpper();
            prods = Buscar(BuscarProduto, quantidade, vetProd);
            if (prods != null)
            {
                Console.WriteLine("Informe a quantidade para adicionar ao estoque");
                int quantiAdd = int.Parse(Console.ReadLine()!);
                prods.AdicionarEstoque(quantiAdd);
            }
            else
            {
                Console.WriteLine("Produto não encontrado");
            }
            break;
        case 5:
            Console.WriteLine("Digite o nome do Produto: ");
            BuscarProduto = Console.ReadLine()!.ToUpper();
            prods = Buscar(BuscarProduto, quantidade, vetProd);
            if (prods != null)
            {
                Console.WriteLine("Informe a quantidade para retirar ao estoque");
                int quantiRet = int.Parse(Console.ReadLine()!);
                prods.RetirarEstoque(quantiRet);
            }
            else
            {
                Console.WriteLine("Produto não encontrado");
            }
            break;
    }
    }
    else
    {
        Console.WriteLine("Digite uma opção valida");
    }
} while (op != 6);


static int CadastroProd(int quantiProdcad, Produto[] vetProduto)
{
    if (quantiProdcad < vetProduto.Length)
    {
        Produto prod = new();
        Console.WriteLine("Nome do Produto: ");
        prod.Nome = Console.ReadLine()!.ToUpper();
        Console.WriteLine("Preço: ");
        prod.PrecoUnit = decimal.Parse(Console.ReadLine()!);
        Console.WriteLine("Quantidade em estoque : ");
        prod.QuantidadeEstoq = int.Parse(Console.ReadLine()!);
        vetProduto[quantiProdcad] = prod;
        quantiProdcad++;
        return quantiProdcad;
    }
    else
    {
        Console.WriteLine("Ta lotado bb");
        return quantiProdcad;
    }
}

static void Cabecalho()
{
    Console.WriteLine("=======================================");
    Console.WriteLine("     Sistema de Estoque do Virtus   ");
    Console.WriteLine("=======================================");
    Console.WriteLine("1. Cadastrar produto");
    Console.WriteLine("2. Listar produto");
    Console.WriteLine("3. Buscar produto");
    Console.WriteLine("4. Adicionar estoque");
    Console.WriteLine("5. Retirar estoque");
    Console.WriteLine("6. Sair");
}

static void Listar(int quantiEs, Produto[] vetorProdutos)
{
    for (int i = 0; i < quantiEs; i++)
    {
        vetorProdutos[i].ExibirProduto();
    }
}

static Produto? Buscar(string buscaProd, int quantProds, Produto[] prodVet)
{
    for (int i = 0; i < quantProds; i++)
    {
        if (prodVet[i].Nome == buscaProd)
        {
            return prodVet[i];
        }
    }
    return null;
}