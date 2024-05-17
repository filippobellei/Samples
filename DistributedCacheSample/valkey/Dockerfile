FROM valkey/valkey

COPY valkey.conf /data
EXPOSE 6379

CMD [ "valkey-server", "/data/valkey.conf"]