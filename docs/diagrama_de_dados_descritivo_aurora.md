# Diagrama Descritivo de Dados

1. **Coleção "Categorias"**:
   - **_id**: Identificador único da categoria.
   - **nome**: Nome da categoria.

2. **Coleção "Categorias Descricritivas"**:
   - **_id_da_categoria**: Essa é uma coleção que extende dados complementares. O seu identificador é uma extensão do __id_ categoria.
   - **descrição**: Descrição da categoria.

3. **Coleção "Categorias Valoradas"**:
   - **_id_da_categoria**: Essa é uma coleção que extende dados complementares. O seu identificador é uma extensão do __id_ categoria.
   - **valor**: Valor da categoria.

4. **Coleção "Hierarquia de Categorias"**:
   - **_id_categoria_pai**: Identificador da categoria que está acima.
   - **_idcategoria_filha**: Identificador da categoria que está abaixo.

5. **Coleção "Raciocínio"**:
   - **_id_memoria**: Identificador da memória que contem o discurso.
   - **_id_categoria**: Identificador da categoria reconhecida no discurso.

6. **Coleção "Memórias"**:
   - **_id**: Identificador único da memória.
   - **discurso**: Texto recebido ou enviado para que a comunicação seja feita.

7. **Coleção "Basilar"**:
   - **_id_do_registro**: Essa é uma coleção que extende dados complementares. O seu identificador é uma extensão do __id_ das coleções **Categorias** e **Memórias**.
   - **data_de_criacao**: Data em que o registro foi motificado na coleção.
   - **data_de_modificação**: Dataa em que o registro foi criado na coleção.
   - **tipo_de_modificação**: Tipo de modificação que foi feita no registro.
   - **_id_do_modificador**: Identificador do modificador do registro.
   - **_id_do_criador**: Identificador do criador do registro.
