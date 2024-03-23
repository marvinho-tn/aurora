# Diagrama Descritivo de Dados

## 1. **Coleção "Categorias"**:
   - **_id**: Identificador único da categoria.
   - **nome**: Nome da categoria.

### Relacionamentos

   - Tem como dependestes as **Categorias Descritivas** e as **Categorias Valoradas**

## 2. **Coleção "Categorias Descricritivas"**:
   - **_id_da_categoria**: Essa é uma coleção que extende dados complementares. O seu identificador é uma extensão do __id_ categoria.
   - **descrição**: Descrição da categoria.

### Relacionamentos

   - Depende das **Caterias** (Base) paea existir

## 3. **Coleção "Categorias Valoradas"**:
   - **_id_da_categoria**: Essa é uma coleção que extende dados complementares. O seu identificador é uma extensão do __id_ categoria.
   - **valor**: Valor da categoria.

### Relacionamentos

   - Depende das **Caterias** (Base) paea existir

## 4. **Coleção "Hierarquia de Categorias"**:
   - **_id_da_categoria_pai**: Identificador da categoria que está acima.
   - **_id_da_categoria_filha**: Identificador da categoria que está abaixo.

### Relacionamentos

   - Diz respeito a uma categoria pode ter subcategorias e ser subcaregoria.

## 5. **Coleção "Estrutura Linguistica"**:
   - **_id_da_memoria**: Identificador da memória que contem o discurso.
   - **_id_da_categoria**: Identificador da categoria reconhecida no discurso.

## 6. **Coleção "Memórias"**:
   - **_id**: Identificador único da memória.
   - **discurso**: Texto recebido ou enviado para que a comunicação seja feita.

### Relacionamentos

   - Se comunica com as **Categorias** para preencher os discursos.

## 7. **Coleção "Basilar"**:
   - **_id_do_registro**: Essa é uma coleção que extende dados complementares. O seu identificador é uma extensão do __id_ das coleções **Categorias** e **Memórias**.
   - **data_de_criacao**: Data em que o registro foi motificado na coleção.
   - **data_de_modificação**: Dataa em que o registro foi criado na coleção.
   - **tipo_de_modificação**: Tipo de modificação que foi feita no registro.

### Relacionamentos

   - Se comunica com as colecoes para extender os seus valores com informacors necessarias a comprremsao de auditoria do codigo