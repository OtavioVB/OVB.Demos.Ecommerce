CREATE DATABASE "ovb_demos_ecommerce";

\c "ovb_demos_ecommerce";

CREATE TABLE "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "Accounts" (
    "Identifier" uuid NOT NULL,
    "Name" VARCHAR NOT NULL,
    "LastName" VARCHAR NOT NULL,
    "Username" VARCHAR NOT NULL,
    "Email" VARCHAR NOT NULL,
    "Password" VARCHAR NOT NULL,
    "TypeAccount" integer NOT NULL,
    "TenantIdentifier" uuid NOT NULL,
    "CorrelationIdentifier" uuid NOT NULL,
    "SourcePlatform" text NOT NULL,
    "ExecutionUser" text NOT NULL,
    CONSTRAINT "PK_ACCOUNT_IDENTIFIER" PRIMARY KEY ("Identifier")
);

CREATE UNIQUE INDEX "UK_UNIQUE_ACCOUNT" ON "Accounts" ("TenantIdentifier", "Username", "Email");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20230304233726_BaseMigration', '7.0.3');