#!/bin/sh

srcdir=`dirname $0`
test -z "$srcdir" && srcdir=.

mkdir -p m4
autoreconf  -i --force --warnings=none -I . -I m4

if test x$NOCONFIGURE = x; then
    echo Running $srcdir/configure $conf_flags "$@" ...
    $srcdir/configure --enable-maintainer-mode $conf_flags "$@" || exit 1
else
    echo Skipping configure process.
fi
