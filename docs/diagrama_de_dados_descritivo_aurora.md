# Diagrama Descritivo de Dados

## 1. **Coleção "Categorias"**

- **_id**: Identificador único do objeto.

### 1.1 Relacionamentos

- Tem como dependentes as coleções de **Nome das Categorias** e **Hierarquia das Categorias**
- Usa da **Memória** como fonte de aprendizado e como objetivo de responder as questoes, seja de onde elas venham

## 2. **Coleção "Nome das Categorias"**

- **_id**: Identificador único do objeto.
- **_id_da_categoria**: Esse é justamente o identificador que faz com que o nome seja parte de uma determinada categoria.
- **nome**: Nome da categoria.

### 2.1 Relacionamentos

- Depende de uma **Categoria** para existir
- Tem como dependentes **Valor das Categorias** e **Significado das Categorias**
- Um **Nome de Categoria** pode servir a várias **Categoias** diferentes.

## 3. **Coleção "Valor das Categorias"**

- **_id**: Identificador único do objeto.
- **_id_do_nome_da_categoria**: Esse é justamente o identificador que faz com que o valor seja atribuido a um determinado nome mesmo que hajam varias categorias com o mesmo nome.
- **valor**: Valor do nome da categoria.

### 3.1 Relacionamentos

- Depende do **Nome da Categoria** para existir que por sua vez depende de uma **Categoria**.
- Um **Valor de Categoria** pode servir a vários **Nomes de Categorias** diferentes.

## 4. **Coleção "Hierarquia de Categorias"**

- **_id_da_categoria**: Identificador da categoria.
- **_id_da_subcategoria**: Identificador da subcategoria.

### 4.1 Relacionamentos

- Diz respeito ao fato de que as **Categorias** podem ter subcategorias e serem subcaregorias.

## 5. **Coleção "Significado das Categorias"**

- **_id**: Identificador único do objeto.
- **_id_do_nome_da_categoria**: Esse é justamente o identificador que faz com que o significado seja atribuido a um determinado nome mesmo que hajam varias categorias com o mesmo nome.
- **significado**: Significado do nome da categoria.

### 5.1 Relacionamentos

- Depende do **Nome da Categoria** para existir que por sua vez depende de uma **Categoria**.
- Um **Significado de Categoria** pode servir a vários **Nomes de Categorias** diferentes.

## 6. **Coleção ""**

- **_id_da_categoria**: Identificador da categoria.
- **_id_da_subcategoria**: Identificador da subcategoria.

### 4.1 Relacionamentos

- Diz respeito ao fato de que as **Categorias** podem ter subcategorias e serem subcaregorias.

## 6. **Coleção "Memórias"**

- **_id**: Identificador único da memória.
- **discurso**: Texto recebido ou enviado para que a comunicação seja feita.

### 6.1 Relacionamentos

- Se comunica com a **Memória** na busca de uma reposta.

## 7. **Coleção "Informação dos Dados"**

- **_id_do_registro**: Essa é uma coleção que implanta os dados complementares. O seu identificador é uma extensão das coleções
- **data_de_criacao**: Data em que o registro foi motificado na coleção.
- **data_de_modificação**: Data em que o registro foi criado na coleção.
- **tipo_de_modificação**: Tipo de modificação que foi feita no registro.

### 7.1 Relacionamentos

- Exetende as coleções **Categorias**, **Nomes das Categorias**, **Significados das Categorias**, **Valores das Categorias**, **Hierarquia das Categorias** e **Memórias** com dados que são essenciais para logs e auditorias no sistema.

## Observação

Não existe uma relação gravada da memória com as categorias aprendidas, oq existe é o raciocínio como forma de serviço que vai buscadr a ligação entre os dois para que o discurso faça sentido.
