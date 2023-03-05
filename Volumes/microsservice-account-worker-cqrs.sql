CREATE DATABASE "ovb_demos_ecommerce_query";

\c "ovb_demos_ecommerce_query";

CREATE TABLE "accounts" (
	"Identifier" uuid NOT NULL,
	"TenantIdentifier" uuid NOT NULL,
	"CorrelationIdentifier" uuid NOT NULL,
	"SourcePlatform" char(8) NOT NULL,
	"ExecutionUser" char(8) NOT NULL,
	"Name" VARCHAR(256) NOT NULL,
	"Username" VARCHAR(256) NOT NULL,
	"LastName" VARCHAR(256) NOT NULL,
	"Email" VARCHAR(256) NOT NULL,
	"Password" VARCHAR(256) NOT NULL,
	"TypeAccount" VARCHAR(32) NOT NULL,
	CONSTRAINT "PK_ACCOUNT_IDENTIFIER" PRIMARY KEY ("Identifier"),
 	CONSTRAINT "UK_ACCOUNT_CREDENTIALS_EMAIL" UNIQUE ("Email"),
	CONSTRAINT "UK_ACCOUNT_CREDENTIALS_USERNAME" UNIQUE ("Username")
);