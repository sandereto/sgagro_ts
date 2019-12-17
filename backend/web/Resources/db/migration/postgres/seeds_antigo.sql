--
-- PostgreSQL database dump
--

-- Dumped from database version 9.6.10
-- Dumped by pg_dump version 9.6.10

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET default_tablespace = '';

SET default_with_oids = false;

CREATE ROLE rebasedata LOGIN
  ENCRYPTED PASSWORD 'rebasedata'
  NOSUPERUSER INHERIT CREATEDB NOCREATEROLE NOREPLICATION;

--
-- Name: _apto_equipamento; Type: TABLE; Schema: reagro; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.apto_equipamento (
    id smallint,
    apto_equipamento_capa_id smallint,
    area_id smallint,
    servico_id smallint,
    implemento_id character varying(2) DEFAULT NULL::character varying,
    descricao character varying(131) DEFAULT NULL::character varying,
    horas_normais character varying(5) DEFAULT NULL::character varying,
    horas_extras character varying(1) DEFAULT NULL::character varying,
    horas_bonificadas character varying(1) DEFAULT NULL::character varying,
    equipamento_horimetro_inicio character varying(8) DEFAULT NULL::character varying,
    equipamento_horimetro_fim character varying(8) DEFAULT NULL::character varying,
    perda character varying(1) DEFAULT NULL::character varying,
    observacao character varying(1) DEFAULT NULL::character varying,
    grupo_perda_id character varying(1) DEFAULT NULL::character varying,
    retrabalho smallint,
    percentual character varying(2) DEFAULT NULL::character varying,
    hectare character varying(1) DEFAULT NULL::character varying,
    criado_em character varying(19) DEFAULT NULL::character varying,
    atualizado_em character varying(19) DEFAULT NULL::character varying,
    usuario_id smallint,
    uuid character varying(36) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.apto_equipamento OWNER TO rebasedata;

--
-- Name: _apto_equipamento_capa; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.apto_equipamento_capa (
    id smallint,
    data character varying(10) DEFAULT NULL::character varying,
    equipamento_id smallint,
    turno_id smallint,
    safra_id smallint,
    pessoa_id smallint,
    horas character varying(1) DEFAULT NULL::character varying,
    dt_hr_gravacao character varying(19) DEFAULT NULL::character varying,
    usuario_id smallint,
    uuid character varying(36) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.apto_equipamento_capa OWNER TO rebasedata;

--
-- Name: _apto_mao_obra_bkp; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.apto_mao_obra_bkp (
    id character varying(1) DEFAULT NULL::character varying,
    data character varying(1) DEFAULT NULL::character varying,
    turno_id character varying(1) DEFAULT NULL::character varying,
    horas_normais character varying(1) DEFAULT NULL::character varying,
    horas_extras character varying(1) DEFAULT NULL::character varying,
    horas_bonificadas character varying(1) DEFAULT NULL::character varying,
    apto_tipo_id character varying(1) DEFAULT NULL::character varying,
    perda character varying(1) DEFAULT NULL::character varying,
    grupo_perda_id character varying(1) DEFAULT NULL::character varying,
    pessoa_id character varying(1) DEFAULT NULL::character varying,
    usuario_id character varying(1) DEFAULT NULL::character varying,
    servico_id character varying(1) DEFAULT NULL::character varying,
    descricao character varying(1) DEFAULT NULL::character varying,
    safra_id character varying(1) DEFAULT NULL::character varying,
    area_id character varying(1) DEFAULT NULL::character varying,
    retrabalho character varying(1) DEFAULT NULL::character varying,
    perc_concluido character varying(1) DEFAULT NULL::character varying,
    hectare character varying(1) DEFAULT NULL::character varying,
    criado_em character varying(1) DEFAULT NULL::character varying,
    atualizado_em character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.apto_mao_obra_bkp OWNER TO rebasedata;

--
-- Name: _apto_mao_obra_capa; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.apto_mao_obra_capa (
    id character varying(1) DEFAULT NULL::character varying,
    data character varying(1) DEFAULT NULL::character varying,
    turno_id character varying(1) DEFAULT NULL::character varying,
    servico_id character varying(1) DEFAULT NULL::character varying,
    safra_id character varying(1) DEFAULT NULL::character varying,
    criado_em character varying(1) DEFAULT NULL::character varying,
    atualizado_em character varying(1) DEFAULT NULL::character varying,
    usuario_id character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.apto_mao_obra_capa OWNER TO rebasedata;

--
-- Name: _apto_mao_obra_perda; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.apto_mao_obra_perda (
    id character varying(1) DEFAULT NULL::character varying,
    apto_mao_obra_id character varying(1) DEFAULT NULL::character varying,
    horas character varying(1) DEFAULT NULL::character varying,
    grupo_perda_id character varying(1) DEFAULT NULL::character varying,
    descricao character varying(1) DEFAULT NULL::character varying,
    criado_em character varying(1) DEFAULT NULL::character varying,
    atualizado_em character varying(1) DEFAULT NULL::character varying,
    usuario_id character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.apto_mao_obra_perda OWNER TO rebasedata;

--
-- Name: _apto_mao_obra_servico; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.apto_mao_obra_servico (
    id character varying(1) DEFAULT NULL::character varying,
    apto_mao_obra_capa_id character varying(1) DEFAULT NULL::character varying,
    area_id character varying(1) DEFAULT NULL::character varying,
    pessoa_id character varying(1) DEFAULT NULL::character varying,
    horas_normais character varying(1) DEFAULT NULL::character varying,
    horas_extras character varying(1) DEFAULT NULL::character varying,
    horas_bonificadas character varying(1) DEFAULT NULL::character varying,
    descricao character varying(1) DEFAULT NULL::character varying,
    criado_em character varying(1) DEFAULT NULL::character varying,
    atualizado_em character varying(1) DEFAULT NULL::character varying,
    usuario_id character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.apto_mao_obra_servico OWNER TO rebasedata;

--
-- Name: _apto_tipo; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.apto_tipo (
    id character varying(1) DEFAULT NULL::character varying,
    nome character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.apto_tipo OWNER TO rebasedata;

--
-- Name: _area; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.area (
    id smallint,
    nome character varying(8) DEFAULT NULL::character varying,
    cliente_id smallint,
    mapa_id smallint,
    area_ha numeric(3,2) DEFAULT NULL::numeric,
    observacao character varying(1) DEFAULT NULL::character varying,
    agrupador character varying(1) DEFAULT NULL::character varying,
    maturidade_solo_id smallint
);


ALTER TABLE sgagro_antigo.area OWNER TO rebasedata;

--
-- Name: _atividade; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.atividade (
    id character varying(1) DEFAULT NULL::character varying,
    nome character varying(1) DEFAULT NULL::character varying,
    cliente_id character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.atividade OWNER TO rebasedata;

--
-- Name: _categoria_mao_obra; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.categoria_mao_obra (
    id smallint,
    nome character varying(10) DEFAULT NULL::character varying,
    cliente_id smallint
);


ALTER TABLE sgagro_antigo.categoria_mao_obra OWNER TO rebasedata;

--
-- Name: _centro_custo; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.centro_custo (
    id character varying(1) DEFAULT NULL::character varying,
    nome character varying(1) DEFAULT NULL::character varying,
    cliente_id character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.centro_custo OWNER TO rebasedata;

--
-- Name: _ci_route; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.ci_route (
    id smallint,
    rota character varying(22) DEFAULT NULL::character varying,
    controller character varying(35) DEFAULT NULL::character varying,
    ativo smallint
);


ALTER TABLE sgagro_antigo.ci_route OWNER TO rebasedata;

--
-- Name: _classe_mao_obra; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.classe_mao_obra (
    id smallint,
    nome character varying(10) DEFAULT NULL::character varying,
    cliente_id smallint,
    horas_bonificacao character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.classe_mao_obra OWNER TO rebasedata;

--
-- Name: _cliente; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.cliente (
    id smallint,
    tipo_cliente character varying(1) DEFAULT NULL::character varying,
    nome_razao character varying(15) DEFAULT NULL::character varying,
    cpf_cnpj character varying(16) DEFAULT NULL::character varying,
    inscricao_estadual character varying(1) DEFAULT NULL::character varying,
    inscricao_municipal character varying(1) DEFAULT NULL::character varying,
    rg character varying(1) DEFAULT NULL::character varying,
    data_nascimento character varying(1) DEFAULT NULL::character varying,
    sexo character varying(1) DEFAULT NULL::character varying,
    nacionalidade character varying(1) DEFAULT NULL::character varying,
    email character varying(1) DEFAULT NULL::character varying,
    telefone character varying(1) DEFAULT NULL::character varying,
    criado_em character varying(1) DEFAULT NULL::character varying,
    usuario_id smallint,
    ativo smallint
);


ALTER TABLE sgagro_antigo.cliente OWNER TO rebasedata;

--
-- Name: _composicao; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.composicao (
    id character varying(1) DEFAULT NULL::character varying,
    nome character varying(1) DEFAULT NULL::character varying,
    cliente_id character varying(1) DEFAULT NULL::character varying,
    unidade_id character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.composicao OWNER TO rebasedata;

--
-- Name: _cotacao; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.cotacao (
    id character varying(1) DEFAULT NULL::character varying,
    nome character varying(1) DEFAULT NULL::character varying,
    cliente_id character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.cotacao OWNER TO rebasedata;

--
-- Name: _cultura; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.cultura (
    id smallint,
    nome character varying(4) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.cultura OWNER TO rebasedata;

--
-- Name: _endereco; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.endereco (
    id character varying(1) DEFAULT NULL::character varying,
    cliente_id character varying(1) DEFAULT NULL::character varying,
    cep character varying(1) DEFAULT NULL::character varying,
    logradouro character varying(1) DEFAULT NULL::character varying,
    numero character varying(1) DEFAULT NULL::character varying,
    bairro character varying(1) DEFAULT NULL::character varying,
    cidade character varying(1) DEFAULT NULL::character varying,
    uf character varying(1) DEFAULT NULL::character varying,
    endereco character varying(1) DEFAULT NULL::character varying,
    endereco_cobranca character varying(1) DEFAULT NULL::character varying,
    criado_em character varying(1) DEFAULT NULL::character varying,
    usuario_id character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.endereco OWNER TO rebasedata;

--
-- Name: _equipamento; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.equipamento (
    id smallint,
    nome character varying(19) DEFAULT NULL::character varying,
    apelido character varying(19) DEFAULT NULL::character varying,
    cliente_id smallint,
    centro_custo_id character varying(1) DEFAULT NULL::character varying,
    equipamento_tipo_id smallint,
    horimetro character varying(1) DEFAULT NULL::character varying,
    horas_acumuladas character varying(1) DEFAULT NULL::character varying,
    horimetro_ativo smallint,
    ativo smallint
);


ALTER TABLE sgagro_antigo.equipamento OWNER TO rebasedata;

--
-- Name: _equipamento_tipo; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.equipamento_tipo (
    id smallint,
    nome character varying(10) DEFAULT NULL::character varying,
    implemento smallint,
    cliente_id smallint,
    imagem character varying(6) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.equipamento_tipo OWNER TO rebasedata;

--
-- Name: _equipe; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.equipe (
    id smallint,
    descricao character varying(8) DEFAULT NULL::character varying,
    cliente_id smallint,
    ativo smallint,
    dt_hr_gravacao character varying(19) DEFAULT NULL::character varying,
    usuario_id smallint
);


ALTER TABLE sgagro_antigo.equipe OWNER TO rebasedata;

--
-- Name: _equipe_pessoa; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.equipe_pessoa (
    id smallint,
    pessoa_id smallint,
    equipe_id smallint,
    ativo smallint,
    dt_hr_gravacao character varying(19) DEFAULT NULL::character varying,
    usuario_id smallint
);


ALTER TABLE sgagro_antigo.equipe_pessoa OWNER TO rebasedata;

--
-- Name: _funcao; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.funcao (
    id smallint,
    nome character varying(5) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.funcao OWNER TO rebasedata;

--
-- Name: _grupo_perda; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.grupo_perda (
    id smallint,
    nome character varying(9) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.grupo_perda OWNER TO rebasedata;

--
-- Name: _grupo_servico; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.grupo_servico (
    id smallint,
    nome character varying(5) DEFAULT NULL::character varying,
    cliente_id smallint
);


ALTER TABLE sgagro_antigo.grupo_servico OWNER TO rebasedata;

--
-- Name: _grupos_acesso; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.grupos_acesso (
    id smallint,
    grupo character varying(19) DEFAULT NULL::character varying,
    ativo smallint
);


ALTER TABLE sgagro_antigo.grupos_acesso OWNER TO rebasedata;

--
-- Name: _grupos_modulos_menus; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.grupos_modulos_menus (
    grupo_id smallint,
    modulo_id character varying(1) DEFAULT NULL::character varying,
    menu_id character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.grupos_modulos_menus OWNER TO rebasedata;

--
-- Name: _grupos_usuarios; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.grupos_usuarios (
    grupo_id smallint,
    usuario_id smallint
);


ALTER TABLE sgagro_antigo.grupos_usuarios OWNER TO rebasedata;

--
-- Name: _insumo; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.insumo (
    id smallint,
    nome character varying(8) DEFAULT NULL::character varying,
    cliente_id smallint,
    unidade_id smallint,
    categoria_insumo_id smallint
);


ALTER TABLE sgagro_antigo.insumo OWNER TO rebasedata;

--
-- Name: _insumo_categoria; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.insumo_categoria (
    id smallint,
    nome character varying(5) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.insumo_categoria OWNER TO rebasedata;

--
-- Name: _insumo_composicao; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.insumo_composicao (
    composicao_id character varying(1) DEFAULT NULL::character varying,
    insumo_id character varying(1) DEFAULT NULL::character varying,
    quantidade character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.insumo_composicao OWNER TO rebasedata;

--
-- Name: _insumo_cotacao; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.insumo_cotacao (
    cotacao_id character varying(1) DEFAULT NULL::character varying,
    insumo_id character varying(1) DEFAULT NULL::character varying,
    moeda_id character varying(1) DEFAULT NULL::character varying,
    valor character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.insumo_cotacao OWNER TO rebasedata;

--
-- Name: _log_erros; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.log_erros (
    id smallint,
    errno smallint,
    errtype character varying(15) DEFAULT NULL::character varying,
    errstr character varying(175) DEFAULT NULL::character varying,
    errfile character varying(73) DEFAULT NULL::character varying,
    errline smallint,
    uri_string character varying(44) DEFAULT NULL::character varying,
    user_agent character varying(120) DEFAULT NULL::character varying,
    ip_address character varying(15) DEFAULT NULL::character varying,
    "time" character varying(19) DEFAULT NULL::character varying,
    versao character varying(5) DEFAULT NULL::character varying,
    usuario_id character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.log_erros OWNER TO rebasedata;

--
-- Name: _log_horimetro_equipamento; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.log_horimetro_equipamento (
    id smallint,
    equipamento_id smallint,
    apto_equipamento_id smallint,
    horas character varying(4) DEFAULT NULL::character varying,
    horimetro_inicial numeric(6,2) DEFAULT NULL::numeric,
    horimetro_final numeric(6,2) DEFAULT NULL::numeric,
    dt_hr_gravacao character varying(19) DEFAULT NULL::character varying,
    usuario_id smallint
);


ALTER TABLE sgagro_antigo.log_horimetro_equipamento OWNER TO rebasedata;

--
-- Name: _mapa; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.mapa (
    id smallint,
    codigo character varying(5) DEFAULT NULL::character varying,
    cliente_id smallint
);


ALTER TABLE sgagro_antigo.mapa OWNER TO rebasedata;

--
-- Name: _maturidade_solo; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.maturidade_solo (
    id smallint,
    nome character varying(5) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.maturidade_solo OWNER TO rebasedata;

--
-- Name: _menus; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.menus (
    id smallint,
    menu character varying(19) DEFAULT NULL::character varying,
    menu_pai character varying(1) DEFAULT NULL::character varying,
    ordem_exibicao numeric(3,1) DEFAULT NULL::numeric,
    ci_route_id character varying(2) DEFAULT NULL::character varying,
    icon_class character varying(26) DEFAULT NULL::character varying,
    ativo smallint
);


ALTER TABLE sgagro_antigo.menus OWNER TO rebasedata;

--
-- Name: _modulos; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.modulos (
    id smallint,
    modulo character varying(19) DEFAULT NULL::character varying,
    menu_id smallint,
    ativo smallint
);


ALTER TABLE sgagro_antigo.modulos OWNER TO rebasedata;

--
-- Name: _moeda; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.moeda (
    id character varying(1) DEFAULT NULL::character varying,
    nome character varying(1) DEFAULT NULL::character varying,
    cliente_id character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.moeda OWNER TO rebasedata;

--
-- Name: _motivo; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.motivo (
    id smallint,
    motivo character varying(11) DEFAULT NULL::character varying,
    ativo smallint
);


ALTER TABLE sgagro_antigo.motivo OWNER TO rebasedata;

--
-- Name: _parametros; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.parametros (
    id smallint,
    environment character varying(11) DEFAULT NULL::character varying,
    categoria character varying(9) DEFAULT NULL::character varying,
    indice character varying(25) DEFAULT NULL::character varying,
    nome_parametro character varying(25) DEFAULT NULL::character varying,
    valor_parametro character varying(26) DEFAULT NULL::character varying,
    descricao character varying(55) DEFAULT NULL::character varying,
    ativo smallint
);


ALTER TABLE sgagro_antigo.parametros OWNER TO rebasedata;

--
-- Name: _pessoa; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.pessoa (
    id smallint,
    nome character varying(36) DEFAULT NULL::character varying,
    cpf character varying(1) DEFAULT NULL::character varying,
    ativo smallint,
    categoria_mao_obra_id smallint,
    classe_mao_obra_id smallint,
    funcao_id smallint,
    cliente_id smallint
);


ALTER TABLE sgagro_antigo.pessoa OWNER TO rebasedata;

--
-- Name: _safra; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.safra (
    id smallint,
    nome character varying(18) DEFAULT NULL::character varying,
    atual smallint,
    data_inicio character varying(1) DEFAULT NULL::character varying,
    data_fim character varying(1) DEFAULT NULL::character varying,
    cliente_id smallint,
    cultura_id smallint,
    unidade_id smallint
);


ALTER TABLE sgagro_antigo.safra OWNER TO rebasedata;

--
-- Name: _safra_area; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.safra_area (
    id character varying(1) DEFAULT NULL::character varying,
    area_id character varying(1) DEFAULT NULL::character varying,
    safra_id character varying(1) DEFAULT NULL::character varying,
    hectares character varying(1) DEFAULT NULL::character varying,
    encarregado character varying(1) DEFAULT NULL::character varying,
    maturidade_solo_id character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.safra_area OWNER TO rebasedata;

--
-- Name: _servico; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.servico (
    id smallint,
    nome character varying(45) DEFAULT NULL::character varying,
    grupo_servico_id smallint,
    cliente_id smallint
);


ALTER TABLE sgagro_antigo.servico OWNER TO rebasedata;

--
-- Name: _token; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.token (
    id character varying(1) DEFAULT NULL::character varying,
    usuario_id character varying(1) DEFAULT NULL::character varying,
    motivo_id character varying(1) DEFAULT NULL::character varying,
    token character varying(1) DEFAULT NULL::character varying,
    dt_token character varying(1) DEFAULT NULL::character varying,
    novo_email character varying(1) DEFAULT NULL::character varying,
    dt_inativacao character varying(1) DEFAULT NULL::character varying,
    ativo character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.token OWNER TO rebasedata;

--
-- Name: _turno; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.turno (
    id smallint,
    nome character varying(10) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.turno OWNER TO rebasedata;

--
-- Name: _unidade; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.unidade (
    id smallint,
    nome character varying(5) DEFAULT NULL::character varying,
    cliente_id smallint
);


ALTER TABLE sgagro_antigo.unidade OWNER TO rebasedata;

--
-- Name: _unidade_taxa_conversao; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.unidade_taxa_conversao (
    unidade_id_de character varying(1) DEFAULT NULL::character varying,
    unidade_id_para character varying(1) DEFAULT NULL::character varying,
    multiplicador character varying(1) DEFAULT NULL::character varying,
    cliente_id character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.unidade_taxa_conversao OWNER TO rebasedata;

--
-- Name: _usuario; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.usuario (
    id smallint,
    nome character varying(12) DEFAULT NULL::character varying,
    cpf character varying(14) DEFAULT NULL::character varying,
    matricula integer,
    email character varying(24) DEFAULT NULL::character varying,
    novo_email character varying(1) DEFAULT NULL::character varying,
    senha character varying(60) DEFAULT NULL::character varying,
    dt_envio_email_ativacao character varying(1) DEFAULT NULL::character varying,
    dt_ativacao character varying(19) DEFAULT NULL::character varying,
    token character varying(1) DEFAULT NULL::character varying,
    dt_token character varying(1) DEFAULT NULL::character varying,
    dt_hr_cadastro character varying(19) DEFAULT NULL::character varying,
    usuario_id smallint,
    ativo smallint
);


ALTER TABLE sgagro_antigo.usuario OWNER TO rebasedata;

--
-- Name: _usuario_pessoa; Type: TABLE; Schema: public; Owner: rebasedata
--

CREATE TABLE sgagro_antigo.usuario_pessoa (
    usuario_id character varying(1) DEFAULT NULL::character varying,
    pessoa_id character varying(1) DEFAULT NULL::character varying
);


ALTER TABLE sgagro_antigo.usuario_pessoa OWNER TO rebasedata;

--
-- Data for Name: _apto_equipamento; Type: TABLE DATA; Schema: reagro; Owner: rebasedata
--
