# Bitmapify

Utility for converting JPEGs and PNGs to XBM (X BitMap).

## Usage

```
bitmapify input_file xbm_name
```

### `input_file`
Should be the path to a PNG or JPEG which contain exclusively white
(ARGB=#FFFFFFFF) and black (ARGB=#00000000). If other colors are found, they'll
be treated as white. Black will be treated as the foreground color in the
XBM file. The library I use for processing the image supports bmp, tga, gif,
psd, hdr and pic files. I haven't tried those, bu they might work!

### `xbm_name`
This can be any name which is valid for a C symbol (i.e., containing letters,
numbers, and underscores, but not starting with a number). Do not include
`.xbm` in the name. This program will produce a XBM file named `xbm_name.xbm` in
the working directory.