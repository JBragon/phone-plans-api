CREATE TABLE DDD (
	Id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY COMMENT 'Identificador da tabela',
	Region VARCHAR(50) NOT NULL COMMENT 'Região em que o código DDD pertence.',
	State VARCHAR(2) NOT NULL COMMENT 'Estado em que o código DDD pertence.',
	DDDCode INT(2) NOT NULL COMMENT 'Código DDD.',
	CreatedAt DATETIME(3) DEFAULT CURRENT_TIMESTAMP(3) COMMENT 'Data de criação do registro.',
	UpdatedAt DATETIME(3) DEFAULT CURRENT_TIMESTAMP(3) ON UPDATE CURRENT_TIMESTAMP(3) COMMENT 'Data de atualização do registro.'
) COMMENT 'Tabela que armazena dados de discagem direta a distância (DDD)';

CREATE TABLE TelephoneOperator (
	Id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY COMMENT 'Identificador da tabela',
	Name VARCHAR(50) NOT NULL COMMENT 'Nome da operadora.',
	CreatedAt DATETIME(3) DEFAULT CURRENT_TIMESTAMP(3) COMMENT 'Data de criação do registro.',
	UpdatedAt DATETIME(3) DEFAULT CURRENT_TIMESTAMP(3) ON UPDATE CURRENT_TIMESTAMP(3) COMMENT 'Data de atualização do registro.'
) COMMENT 'Tabela que armazena dados das operadoras de telefonia';

CREATE TABLE PhonePlanType (
	Id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY COMMENT 'Identificador da tabela',
	Description VARCHAR(50) NOT NULL COMMENT 'Descrição do tipo.',
	CreatedAt DATETIME(3) DEFAULT CURRENT_TIMESTAMP(3) COMMENT 'Data de criação do registro.',
	UpdatedAt DATETIME(3) DEFAULT CURRENT_TIMESTAMP(3) ON UPDATE CURRENT_TIMESTAMP(3) COMMENT 'Data de atualização do registro.'
) COMMENT 'Tabela que armazena os tipos de plano de telefonia';

CREATE TABLE PhonePlan (
	Id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY COMMENT 'Identificador da tabela e código do plano',
	DDDId INT UNSIGNED NOT NULL COMMENT 'Identificador do DDD.',
    TelephoneOperatorId INT UNSIGNED NOT NULL COMMENT 'Identificador da operadora telefônica.',
    PhonePlanTypeId INT UNSIGNED NOT NULL COMMENT 'Identificador do tipo da operadora telefônica.',
	Minutes DECIMAL(6,2) NOT NULL COMMENT 'Franquia de minutos do plano.',
    InternetFranchise DECIMAL(10,2) NOT NULL COMMENT 'Franquia de internet do plano.',
    PlanPrice DECIMAL(10,2) NOT NULL COMMENT 'Valor do plano.',
    Name VARCHAR(50) NOT NULL COMMENT 'Nome do plano.',
    CreatedAt DATETIME(3) DEFAULT CURRENT_TIMESTAMP(3) COMMENT 'Data de criação do registro.',
	UpdatedAt DATETIME(3) DEFAULT CURRENT_TIMESTAMP(3) ON UPDATE CURRENT_TIMESTAMP(3) COMMENT 'Data de atualização do registro.',
    CONSTRAINT UC_PhonePlan UNIQUE (DDDId, TelephoneOperatorId, Name),
	CONSTRAINT PhonePlan_DDD_fk FOREIGN KEY (DDDId) REFERENCES DDD (Id) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT PhonePlan_TelephoneOperator_fk FOREIGN KEY (TelephoneOperatorId) REFERENCES TelephoneOperator (Id) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT PhonePlan_PhonePlanType_fk FOREIGN KEY (PhonePlanTypeId) REFERENCES PhonePlanType (Id) ON DELETE CASCADE ON UPDATE CASCADE
) COMMENT 'Tabela que armazena dados mdfe_condutor';


