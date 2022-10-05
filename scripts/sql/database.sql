-- STRUCTURE
DROP SCHEMA IF EXISTS "budget" CASCADE ;
CREATE SCHEMA "budget";

CREATE TABLE "budget"."receipts" (
  "id" SERIAL PRIMARY KEY,
  "issue_date" DATE NOT NULL,
  "issuer_id" INT NOT NULL
);

CREATE TABLE "budget"."issuers" (
    "id" SERIAL PRIMARY KEY,
    "name" VARCHAR(50) NOT NULL,
    "category_id" INT NOT NULL 
);

CREATE TABLE "budget"."issuer_categories" (
    "id" SERIAL PRIMARY KEY,
    "name" VARCHAR(50) NOT NULL
);

ALTER TABLE "budget"."receipts" 
    ADD FOREIGN KEY ("issuer_id") REFERENCES "budget"."issuers" ("id");

ALTER TABLE "budget"."issuers"
    ADD FOREIGN KEY ("category_id") REFERENCES "budget"."issuer_categories" ("id");


-- DATA
INSERT INTO "budget"."issuer_categories" (name)
VALUES ('Sklep spożywczy');

INSERT INTO "budget"."issuers" (name, category_id) 
VALUES ('Lidl', 1), ('Biedronka', 1)

INSERT INTO "budget"."receipts" (issue_date, issuer_id) 
VALUES ('2022-10-04', 1), ('2022-10-05', 2)