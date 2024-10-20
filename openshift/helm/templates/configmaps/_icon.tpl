{{- define "icon.ico" -}}
  {{ $.Files.Get "oauth-proxy-custom-template/icon.ico" | b64enc }}
{{- end -}}