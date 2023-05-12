CREATE TABLE users
(
    id                SERIAL8 PRIMARY KEY,
    username          TEXT UNIQUE NOT NULL,
    password          TEXT        NULL,
    password_salt     TEXT        NULL,
    display_name      TEXT        NOT NULL,
    profile_image_url TEXT UNIQUE NULL
);

CREATE TABLE wishlists
(
    id          SERIAL8 PRIMARY KEY,
    name        TEXT        NOT NULL,
    owner_id    INT8 REFERENCES users (id),
    description TEXT        NULL,
    private     BOOL        NOT NULL DEFAULT FALSE,
    image_url   TEXT UNIQUE NULL,
    UNIQUE (name, owner_id)
);

CREATE TABLE wishes
(
    id           SERIAL8 PRIMARY KEY,
    name         TEXT        NOT NULL,
    wishlist_id  INT8 REFERENCES wishlists (id),
    presenter_id INT8 REFERENCES users (id),
    description  TEXT        NULL,
    price        MONEY       NULL,
    image_url    TEXT UNIQUE NULL,
    UNIQUE (name, wishlist_id)
);